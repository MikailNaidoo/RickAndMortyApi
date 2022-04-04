using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RickAndMortyApi.CharacterService.Characters;

public class CharacterPublicAppService:CharacterServiceAppService,ICharacterPublicAppService
{
    
    public async Task<CharacterDto> getCharacter(int Id)
    {
        CharacterDto characterDto = new CharacterDto();
        using(var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://rickandmortyapi.com/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method
            HttpResponseMessage response = await client.GetAsync("character/"+Id.ToString());
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                characterDto=JsonConvert.DeserializeObject<CharacterDto>(result);
            }
           
        }

        return characterDto;
    }

    public async Task<AllCharactersDto> getAllCharacters()
    {
        AllCharactersDto characters = new AllCharactersDto();
        using(var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://rickandmortyapi.com/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method
            HttpResponseMessage response = await client.GetAsync("character");
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                characters=JsonConvert.DeserializeObject<AllCharactersDto>(result);
            }
           
        }

        return characters;
    }
}