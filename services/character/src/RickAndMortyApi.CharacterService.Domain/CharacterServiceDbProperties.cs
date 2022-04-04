namespace RickAndMortyApi.CharacterService;

public static class CharacterServiceDbProperties
{
    public static string DbTablePrefix { get; set; } = "";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "CharacterService";
}
