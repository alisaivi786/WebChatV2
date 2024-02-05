using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebChat.Presistence.SeedConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasData(
             new UserEntity
             {
                 Id = 1,
                 UserName = "Ali",
                 PhoneNumber = "971505679899",
                 CreatedBy = 1
             },
             new UserEntity
             {
                 Id = 2,
                 UserName = "Poonam",
                 PhoneNumber = "971505679800",
                 CreatedBy = 2
             },
             new UserEntity
             {
                 Id = 3,
                 UserName = "Aymen",
                 PhoneNumber = "971505679888",
                 CreatedBy = 3
             }

        );
    }
}
