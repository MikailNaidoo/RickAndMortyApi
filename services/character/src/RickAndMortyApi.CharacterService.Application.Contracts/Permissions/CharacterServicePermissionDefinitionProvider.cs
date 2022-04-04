using RickAndMortyApi.CharacterService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace RickAndMortyApi.CharacterService.Permissions;

public class CharacterServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CharacterServicePermissions.GroupName, L("Permission:CharacterService"));

        //Define your own permissions here. Example:
        //myGroup.AddPermission(BookStorePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CharacterServiceResource>(name);
    }
}
