using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebChat.Presistence.SeedConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<UserDetailsEntity>
{
    public void Configure(EntityTypeBuilder<UserDetailsEntity> builder)
    {
    }
}
