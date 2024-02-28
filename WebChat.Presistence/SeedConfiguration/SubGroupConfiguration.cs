using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebChat.Presistence.SeedConfiguration;

public class SubGroupConfiguration : IEntityTypeConfiguration<SubGroupEntity>
{
    public void Configure(EntityTypeBuilder<SubGroupEntity> builder)
    {
        builder.HasData(
             new SubGroupEntity
             {
                 Id = 1,
                 Name = "10 Minute",
                 GroupId = 1,
                 CreatedBy = 1
             },
             new SubGroupEntity
             {
                 Id = 2,
                 Name = "10 Minute",
                 GroupId = 2,
                 CreatedBy = 1
             },
             new SubGroupEntity
             {
                 Id = 3,
                 Name = "10 Minute",
                 GroupId = 3,
                 CreatedBy = 1
             },
             new SubGroupEntity
             {
                 Id = 4,
                 Name = "10 Minute",
                 GroupId = 4,
                 CreatedBy = 1
             }

        );
    }
}
