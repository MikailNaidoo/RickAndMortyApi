using RickAndMortyApi.CharacterService.Localization;
using Volo.Abp.Application.Services;

namespace RickAndMortyApi.CharacterService;

public abstract class CharacterServiceAppService : ApplicationService
{
    protected CharacterServiceAppService()
    {
        LocalizationResource = typeof(CharacterServiceResource);
        ObjectMapperContext = typeof(CharacterServiceApplicationModule);
    }
}
