using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RickAndMortyApi.AdministrationService.DbMigrations;
using RickAndMortyApi.AdministrationService.EntityFrameworkCore;
using RickAndMortyApi.IdentityService;
using RickAndMortyApi.ProductService;
using RickAndMortyApi.SaasService;
using RickAndMortyApi.Shared.Hosting.Microservices;
using Prometheus;
using RickAndMortyApi.CharacterService;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.Http.Client.IdentityModel.Web;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace RickAndMortyApi.AdministrationService;

[DependsOn(
    typeof(RickAndMortyApiSharedLocalizationModule),
    typeof(AbpHttpClientIdentityModelWebModule),
    typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
    typeof(AbpIdentityHttpApiClientModule),
    typeof(AbpAccountAdminApplicationContractsModule),
    typeof(AbpAccountPublicApplicationContractsModule),
    typeof(RickAndMortyApiSharedHostingMicroservicesModule),
    typeof(ProductServiceApplicationContractsModule),
    typeof(SaasServiceApplicationContractsModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(AdministrationServiceApplicationModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceHttpApiModule),
    typeof(CharacterServiceApplicationContractsModule)
    
)]
public class AdministrationServiceHttpApiHostModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // Enable if you need these
        // var configuration = context.Services.GetConfiguration();
        // var hostingEnvironment = context.Services.GetHostingEnvironment();

        JwtBearerConfigurationHelper.Configure(context, "AdministrationService");
        SwaggerConfigurationHelper.Configure(context, "Administration Service API");
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
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Administration Service API");
        });
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
                .GetRequiredService<AdministrationServiceDatabaseMigrationChecker>()
                .CheckAsync();
        }
    }
}
