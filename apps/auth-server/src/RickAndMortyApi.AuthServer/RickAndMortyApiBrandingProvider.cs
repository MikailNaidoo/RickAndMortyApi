using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace RickAndMortyApi.AuthServer;

[Dependency(ReplaceServices = true)]
public class RickAndMortyApiBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "RickAndMortyApi";
}
