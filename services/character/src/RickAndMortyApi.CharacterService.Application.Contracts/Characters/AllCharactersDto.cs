using System.Collections.Generic;

namespace RickAndMortyApi.CharacterService.Characters;

public class AllCharactersDto
{
    public Info info { get; set; }
    public List<CharacterDto> results { get; set; }
    
}