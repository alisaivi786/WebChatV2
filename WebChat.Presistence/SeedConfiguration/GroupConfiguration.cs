using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebChat.Presistence.SeedConfiguration;

public class GroupConfiguration : IEntityTypeConfiguration<GroupEntity>
{
    public void Configure(EntityTypeBuilder<GroupEntity> builder)
    {
        builder.HasData(
             new GroupEntity
             {
                 Id = 1,
                 Name = "Win",
                 CreatedBy = 1
             },
             new GroupEntity
             {
                 Id = 2,
                 Name = "5D",
                 CreatedBy = 1
             },
             new GroupEntity
             {
                 Id = 3,
                 Name = "K3",
                 CreatedBy = 1
             },
             new GroupEntity
             {
                 Id = 4,
                 Name = "TrxWin",
                 CreatedBy = 1
             }

        );
    }
}
