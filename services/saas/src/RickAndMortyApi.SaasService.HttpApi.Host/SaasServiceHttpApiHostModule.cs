using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RickAndMortyApi.SaasService.Application;
using RickAndMortyApi.SaasService.DbMigrations;
using RickAndMortyApi.SaasService.EntityFramework;
using RickAndMortyApi.Shared.Hosting.Microservices;
using Prometheus;
using Volo.Abp;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace RickAndMortyApi.SaasService;

[DependsOn(
    typeof(RickAndMortyApiSharedHostingMicroservicesModule),
    typeof(SaasServiceEntityFrameworkCoreModule),
    typeof(SaasServiceApplicationModule),
    typeof(SaasServiceHttpApiModule)
)]
public class SaasServiceHttpApiHostModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // Enable if you need these
        // var configuration = context.Services.GetConfiguration();
        // var hostingEnvironment = context.Services.GetHostingEnvironment();

        context.Services.AddAbpDbContext<SaasServiceDbContext>();

        JwtBearerConfigurationHelper.Configure(context, "SaasService");
        SwaggerConfigurationHelper.Configure(context, "Saas Service API");
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCorrelationId();
        app.UseAbpRequestLocalization();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseHttpMetrics();
        app.UseAuthentication();
        app.UseAbpClaimsMap();
        app.UseMultiTenancy();
        app.UseAuthorization();
        app.UseSwagger();
        app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "Saas Service API"); });
        app.UseAbpSerilogEnrichers();
        app.UseAuditing();
        app.UseUnitOfWork();
        app.UseConfiguredEndpoints(endpoints =>
        {
            endpoints.MapMetrics();
        });
    }

    public async override Task OnPostApplicationInitializationAsync(ApplicationInitializationContext context)
    {
        using (var scope = context.ServiceProvider.CreateScope())
        {
            await scope.ServiceProvider
                .GetRequiredService<SaasServiceDatabaseMigrationChecker>()
                .CheckAsync();
        }
    }
}
