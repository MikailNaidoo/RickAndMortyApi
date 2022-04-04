param ($version='latest')

$currentFolder = $PSScriptRoot
$slnFolder = Join-Path $currentFolder "../"
### Apps Folders
$angularAppFolder = Join-Path $slnFolder "apps/angular"
$mvcAppFolder = Join-Path $slnFolder "apps/web/src/RickAndMortyApi.Web"
$blazorServerAppFolder = Join-Path $slnFolder "apps/blazor/src/RickAndMortyApi.Blazor.Server"
$blazorAppFolder = Join-Path $slnFolder "apps/blazor/src/RickAndMortyApi.Blazor"
$authserverFolder = Join-Path $slnFolder "apps/auth-server/src/RickAndMortyApi.AuthServer"
$publicWebFolder = Join-Path $slnFolder "apps/public-web/src/RickAndMortyApi.PublicWeb"

# Microservice Folders
$identityServiceFolder = Join-Path $slnFolder "services/identity/src/RickAndMortyApi.IdentityService.HttpApi.Host"
$administrationServiceFolder = Join-Path $slnFolder "services/administration/src/RickAndMortyApi.AdministrationService.HttpApi.Host"
$saasServiceFolder = Join-Path $slnFolder "services/saas/src/RickAndMortyApi.SaasService.HttpApi.Host"
$productServiceFolder = Join-Path $slnFolder "services/product/src/RickAndMortyApi.ProductService.HttpApi.Host"

### Gateway Folders
$webGatewayFolder = Join-Path $slnFolder "gateways/web/src/RickAndMortyApi.WebGateway"
$webPublicGatewayFolder = Join-Path $slnFolder "gateways/web-public/src/RickAndMortyApi.PublicWebGateway"

### DB Migrator Folder
$dbmigratorFolder = Join-Path $slnFolder "shared/RickAndMortyApi.DbMigrator"

### IDENTITY-SERVICE
Write-Host "*** BUILDING DB MIGRATOR ***" -ForegroundColor Green
Set-Location $dbmigratorFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/rickandmortyapi-db-migrator:$version .

Write-Host "===== BUILDING MICROSERVICES =====" -ForegroundColor Yellow 
### IDENTITY-SERVICE
Write-Host "*** BUILDING IDENTITY-SERVICE ***" -ForegroundColor Green
Set-Location $identityServiceFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/rickandmortyapi-service-identity:$version .

### ADMINISTRATION-SERVICE
Write-Host "*** BUILDING ADMINISTRATION-SERVICE ***" -ForegroundColor Green
Set-Location $administrationServiceFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/rickandmortyapi-service-administration:$version .

### SAAS-SERVICE
Write-Host "*** BUILDING SAAS-SERVICE ***" -ForegroundColor Green
Set-Location $saasServiceFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/rickandmortyapi-service-saas:$version .

### PRODUCT-SERVICE
Write-Host "*** BUILDING SAAS-SERVICE ***" -ForegroundColor Green
Set-Location $productServiceFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/rickandmortyapi-service-product:$version .
Write-Host "===== COMPLETED BUILDING MICROSERVICES =====" -ForegroundColor Yellow 


Write-Host "===== BUILDING GATEWAYS =====" -ForegroundColor Yellow 
### WEB-GATEWAY
Write-Host "*** BUILDING WEB-GATEWAY ***" -ForegroundColor Green
Set-Location $webGatewayFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/rickandmortyapi-gateway-web:$version .

### PUBLICWEB-GATEWAY
Write-Host "*** BUILDING WEB-PUBLIC-GATEWAY ***" -ForegroundColor Green
Set-Location $webPublicGatewayFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/rickandmortyapi-gateway-web-public:$version .
Write-Host "===== COMPLETED BUILDING GATEWAYS =====" -ForegroundColor Yellow 


Write-Host "===== BUILDING APPLICATIONS =====" -ForegroundColor Yellow 
### AUTH-SERVER
Write-Host "*** BUILDING AUTH-SERVER ***" -ForegroundColor Green
Set-Location $authserverFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/rickandmortyapi-app-authserver:$version .

### PUBLIC-WEB
Write-Host "*** BUILDING WEB-PUBLIC ***" -ForegroundColor Green
Set-Location $publicWebFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/rickandmortyapi-app-publicweb:$version .

### Angular WEB App
if (Test-Path -Path $angularAppFolder) {
    Write-Host "*** BUILDING ANGULAR WEB APPLICATION ***" -ForegroundColor Green
    Set-Location $angularAppFolder
    yarn
    # ng build --prod
    npm run build:prod
    docker build -f Dockerfile.local -t mycompanyname/rickandmortyapi-app-angular:$version .
}

### MVC WEB App
if (Test-Path -Path $mvcAppFolder) {
    Write-Host "*** BUILDING MVC WEB APPLICATION ***" -ForegroundColor Green
    Set-Location $mvcAppFolder
    dotnet publish -c Release
    docker build -f Dockerfile.local -t mycompanyname/rickandmortyapi-app-web:$version .
}

### Blazor WEB App
if (Test-Path -Path $blazorAppFolder) {
    Write-Host "*** BUILDING BLAZOR WEB APPLICATION ***" -ForegroundColor Green
    Set-Location $blazorAppFolder
    dotnet publish -c Release
    docker build -f Dockerfile.local -t mycompanyname/rickandmortyapi-app-blazor:$version .
}

### Blazor-Server WEB App
if (Test-Path -Path $blazorServerAppFolder) {
    Write-Host "*** BUILDING BLAZOR SERVER WEB APPLICATION ***" -ForegroundColor Green
    Set-Location $blazorServerAppFolder
    dotnet publish -c Release
    docker build -f Dockerfile.local -t mycompanyname/rickandmortyapi-app-blazor-server:$version .
}
Write-Host "===== COMPLETED BUILDING APPLICATIONS =====" -ForegroundColor Yellow 
### ALL COMPLETED
Write-Host "ALL COMPLETED" -ForegroundColor Green
Set-Location $currentFolder