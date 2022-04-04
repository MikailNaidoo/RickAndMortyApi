using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace RickAndMortyApi.CharacterService.Characters;


[RemoteService(Name = CharacterServiceRemoteServiceConsts.RemoteServiceName)]
[Area("CharacterService")]
[ControllerName("CharacterService")]
[Route("api/character-service/character")]
public class CharacterController
{
    
    private readonly ICharacterPublicAppService _characterAppService;

    public CharacterController(ICharacterPublicAppService characterAppService)
    {
        _characterAppService = characterAppService;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<CharacterDto> GetAsync(int id)
    {
        return await _characterAppService.getCharacter(id);
    }
    
    [HttpGet]
    public async Task<AllCharactersDto> GetAsync()
    {
        return await _characterAppService.getAllCharacters();
    }
}