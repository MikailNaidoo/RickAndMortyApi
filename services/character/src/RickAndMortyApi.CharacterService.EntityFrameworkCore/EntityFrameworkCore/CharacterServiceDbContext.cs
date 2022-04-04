using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace RickAndMortyApi.CharacterService.EntityFrameworkCore;

[ConnectionStringName(CharacterServiceDbProperties.ConnectionStringName)]
public class CharacterServiceDbContext : AbpDbContext<CharacterServiceDbContext>
{

    public CharacterServiceDbContext(DbContextOptions<CharacterServiceDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureCharacterService();
    }
}
