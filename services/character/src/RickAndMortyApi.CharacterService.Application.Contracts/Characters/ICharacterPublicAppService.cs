using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace RickAndMortyApi.CharacterService.Characters;

public interface ICharacterPublicAppService:IApplicationService
{
    Task<CharacterDto> getCharacter(int Id);
    Task<AllCharactersDto> getAllCharacters();
}