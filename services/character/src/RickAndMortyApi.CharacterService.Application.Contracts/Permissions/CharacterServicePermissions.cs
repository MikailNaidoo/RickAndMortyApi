using Volo.Abp.Reflection;

namespace RickAndMortyApi.CharacterService.Permissions;

public class CharacterServicePermissions
{
    public const string GroupName = "CharacterService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(CharacterServicePermissions));
    }
}
