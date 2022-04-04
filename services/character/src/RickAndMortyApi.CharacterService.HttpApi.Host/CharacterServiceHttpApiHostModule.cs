using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using RickAndMortyApi.CharacterService.EntityFrameworkCore;
using RickAndMortyApi.Shared.Hosting.Microservices;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace RickAndMortyApi.CharacterService;

[DependsOn(
    typeof(RickAndMortyApiSharedHostingMicroservicesModule),
    typeof(CharacterServiceApplicationModule),
    typeof(CharacterServiceHttpApiModule),
    typeof(CharacterServiceEntityFrameworkCoreModule)
    )]
public class CharacterServiceHttpApiHostModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // Enable if you need these
        // var configuration = context.Services.GetConfiguration();
        // var hostingEnvironment = context.Services.GetHostingEnvironment();

        JwtBearerConfigurationHelper.Configure(context, "CharacterService");
        SwaggerConfigurationHelper.Configure(context, "CharacterService API");
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
        app.UseAuthentication();
        app.UseAbpClaimsMap();
        app.UseMultiTenancy();
        app.UseAuthorization();
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "CharacterService API");
        });
        app.UseAbpSerilogEnrichers();
        app.UseAuditing();
        app.UseUnitOfWork();
        app.UseConfiguredEndpoints();
    }
}
