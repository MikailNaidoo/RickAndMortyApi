FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# It's important to keep lines from here down to "COPY . ." identical in all Dockerfiles
# to take advantage of Docker's build cache, to speed up local container builds
COPY "RickAndMortyApi.sln" "RickAndMortyApi.sln"

# Applications
COPY "apps/auth-server/src/RickAndMortyApi.AuthServer/RickAndMortyApi.AuthServer.csproj" "apps/auth-server/src/RickAndMortyApi.AuthServer/RickAndMortyApi.AuthServer.csproj"
COPY "apps/public-web/src/RickAndMortyApi.PublicWeb/RickAndMortyApi.PublicWeb.csproj" "apps/public-web/src/RickAndMortyApi.PublicWeb/RickAndMortyApi.PublicWeb.csproj"
COPY *"apps/blazor/src/RickAndMortyApi.Blazor/RickAndMortyApi.Blazor.csproj" "apps/blazor/src/RickAndMortyApi.Blazor/RickAndMortyApi.Blazor.csproj"
COPY *"apps/blazor/src/RickAndMortyApi.Blazor.Server/RickAndMortyApi.Blazor.Server.csproj" "apps/blazor/src/RickAndMortyApi.Blazor.Server/RickAndMortyApi.Blazor.Server.csproj"
COPY *"apps/web/src/RickAndMortyApi.Web/RickAndMortyApi.Web.csproj" "apps/web/src/RickAndMortyApi.Web/RickAndMortyApi.Web.csproj"

# Shared Projects
COPY "shared/RickAndMortyApi.DbMigrator/RickAndMortyApi.DbMigrator.csproj" "shared/RickAndMortyApi.DbMigrator/RickAndMortyApi.DbMigrator.csproj"
COPY "shared/RickAndMortyApi.Shared.Hosting/RickAndMortyApi.Shared.Hosting.csproj" "shared/RickAndMortyApi.Shared.Hosting/RickAndMortyApi.Shared.Hosting.csproj"
COPY "shared/RickAndMortyApi.Shared.Hosting.Gateways/RickAndMortyApi.Shared.Hosting.Gateways.csproj" "shared/RickAndMortyApi.Shared.Hosting.Gateways/RickAndMortyApi.Shared.Hosting.Gateways.csproj"
COPY "shared/RickAndMortyApi.Shared.Hosting.Microservices/RickAndMortyApi.Shared.Hosting.Microservices.csproj" "shared/RickAndMortyApi.Shared.Hosting.Microservices/RickAndMortyApi.Shared.Hosting.Microservices.csproj"
COPY "shared/RickAndMortyApi.Shared.Hosting.AspNetCore/RickAndMortyApi.Shared.Hosting.AspNetCore.csproj" "shared/RickAndMortyApi.Shared.Hosting.AspNetCore/RickAndMortyApi.Shared.Hosting.AspNetCore.csproj"
COPY "shared/RickAndMortyApi.Shared.Hosting/RickAndMortyApi.Shared.Hosting.csproj" "shared/RickAndMortyApi.Shared.Hosting/RickAndMortyApi.Shared.Hosting.csproj"
COPY "shared/RickAndMortyApi.Shared.Localization/RickAndMortyApi.Shared.Localization.csproj" "shared/RickAndMortyApi.Shared.Localization/RickAndMortyApi.Shared.Localization.csproj"

# Microservices
COPY "services/administration/src/RickAndMortyApi.AdministrationService.HttpApi.Host/RickAndMortyApi.AdministrationService.HttpApi.Host.csproj" "services/administration/src/RickAndMortyApi.AdministrationService.HttpApi.Host/RickAndMortyApi.AdministrationService.HttpApi.Host.csproj"
COPY "services/identity/src/RickAndMortyApi.IdentityService.HttpApi.Host/RickAndMortyApi.IdentityService.HttpApi.Host.csproj" "services/identity/src/RickAndMortyApi.IdentityService.HttpApi.Host/RickAndMortyApi.IdentityService.HttpApi.Host.csproj"
COPY "services/saas/src/RickAndMortyApi.SaasService.HttpApi.Host/RickAndMortyApi.SaasService.HttpApi.Host.csproj" "services/saas/src/RickAndMortyApi.SaasService.HttpApi.Host/RickAndMortyApi.SaasService.HttpApi.Host.csproj"
COPY "services/product/src/RickAndMortyApi.ProductService.HttpApi.Host/RickAndMortyApi.ProductService.HttpApi.Host.csproj" "services/product/src/RickAndMortyApi.ProductService.HttpApi.Host/RickAndMortyApi.ProductService.HttpApi.Host.csproj"
# Gateways
COPY "gateways/web/src/RickAndMortyApi.WebGateway/RickAndMortyApi.WebGateway.csproj" "gateways/web/src/RickAndMortyApi.WebGateway/RickAndMortyApi.WebGateway.csproj"
COPY "gateways/web-public/src/RickAndMortyApi.PublicWebGateway/RickAndMortyApi.PublicWebGateway.csproj" "gateways/web-public/src/RickAndMortyApi.PublicWebGateway/RickAndMortyApi.PublicWebGateway.csproj"

COPY "NuGet.Config" "NuGet.Config"

RUN dotnet restore "RickAndMortyApi.sln"

COPY . .
WORKDIR "/src/services/identity/src/RickAndMortyApi.IdentityService.HttpApi.Host"
RUN dotnet publish -c Release -o /app
# Should be used after .net6 is out of preview for better performance
# RUN dotnet publish --no-restore -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RickAndMortyApi.IdentityService.HttpApi.Host.dll"]