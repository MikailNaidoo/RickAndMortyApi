using RickAndMortyApi.CharacterService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace RickAndMortyApi.CharacterService;

public abstract class CharacterServiceController : AbpControllerBase
{
    protected CharacterServiceController()
    {
        LocalizationResource = typeof(CharacterServiceResource);
    }
}
