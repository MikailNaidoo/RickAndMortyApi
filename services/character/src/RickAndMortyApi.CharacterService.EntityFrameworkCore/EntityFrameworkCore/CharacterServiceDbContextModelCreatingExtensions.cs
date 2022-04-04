using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace RickAndMortyApi.CharacterService.EntityFrameworkCore;

public static class CharacterServiceDbContextModelCreatingExtensions
{
    public static void ConfigureCharacterService(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(CharacterServiceConsts.DbTablePrefix + "YourEntities", CharacterServiceConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
