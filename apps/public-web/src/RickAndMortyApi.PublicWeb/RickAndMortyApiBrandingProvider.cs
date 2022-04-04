using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace RickAndMortyApi.PublicWeb;

[Dependency(ReplaceServices = true)]
public class RickAndMortyApiBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "RickAndMortyApi";
}
