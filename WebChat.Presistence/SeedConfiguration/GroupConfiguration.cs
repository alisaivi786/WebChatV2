using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebChat.Presistence.SeedConfiguration;

public class GroupConfiguration : IEntityTypeConfiguration<GroupEntitiy>
{
    public void Configure(EntityTypeBuilder<GroupEntitiy> builder)
    {
        builder.HasData(
             new GroupEntitiy
             {
                 Id = 1,
                 Name = "TB-Admin",
                 CreatedBy = 1
             }

        );
    }
}
