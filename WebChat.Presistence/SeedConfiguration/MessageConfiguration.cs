using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebChat.Presistence.SeedConfiguration;

public class MessageConfiguration : IEntityTypeConfiguration<MessageEntity>
{
    public void Configure(EntityTypeBuilder<MessageEntity> builder)
    {
        builder.HasData(
             new MessageEntity
             {
                 Id = 1,
                 GroupId = 1,
                 UserId = 1,
                 Content = "Hello Team",
                 CreatedBy = 1
             },
             new MessageEntity
             {
                 Id = 2,
                 GroupId = 1,
                 UserId = 2,
                 Content = "Hey Ali!",
                 CreatedBy = 2
             },
             new MessageEntity
             {
                 Id = 3,
                 GroupId = 1,
                 UserId = 1,
                 Content = "I am Fine Poonam what about you?",
                 CreatedBy = 1
             },
             new MessageEntity
             {
                 Id = 4,
                 GroupId = 1,
                 UserId = 2,
                 Content = "Good to hear you are good, thanks for asking i am also fine!.",
                 CreatedBy = 2
             },
             new MessageEntity
             {
                 Id = 5,
                 GroupId = 1,
                 UserId = 3,
                 Content = "hey Guys whats the update of our chat v1 Project???.",
                 CreatedBy = 3
             },
             new MessageEntity
             {
                 Id = 6,
                 GroupId = 1,
                 UserId = 1,
                 Content = "Architecture of Project is done just doing some final tweaks and then update you here in group.",
                 CreatedBy = 1
             }

        );
    }
}
