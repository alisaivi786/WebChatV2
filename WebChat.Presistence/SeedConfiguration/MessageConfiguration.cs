using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace WebChat.Presistence.SeedConfiguration;

public class MessageConfiguration : IEntityTypeConfiguration<MessageEntity>
{
    public void Configure(EntityTypeBuilder<MessageEntity> builder)
    {
        builder.HasData(
            new MessageEntity
            {
                Id = 1,
                Content = "Hello Team!",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 2,
                Content = "Did you watch the recent cricket match?",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 3,
                Content = "Yes, it was an exciting game!",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 4,
                Content = "Who do you think will win the upcoming elections?",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 5,
                Content = "I'm not sure, it's hard to predict.",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 6,
                Content = "I think the cricket team needs better bowling.",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 7,
                Content = "What's your favorite cricket team?",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 8,
                Content = "I support the national team!",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 9,
                Content = "Cricket is so popular, isn't it?",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 10,
                Content = "I heard there's a new political party forming.",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 11,
                Content = "Really? What's their agenda?",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 12,
                Content = "I hope they focus on education and healthcare.",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 13,
                Content = "Have you ever been to a live cricket match?",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 14,
                Content = "Yes, the atmosphere is incredible!",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 15,
                Content = "Let's plan a movie night this weekend.",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 16,
                Content = "Sure, I'm up for it!",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 17,
                Content = "I'll bring the popcorn!",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 18,
                Content = "What's your take on the current economic situation?",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 19,
                Content = "It's quite challenging, especially for small businesses.",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 20,
                Content = "We should stay positive and support local businesses.",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 21,
                Content = "What's your favorite cuisine?",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 22,
                Content = "I love Italian food!",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 23,
                Content = "Mexican cuisine is my go-to choice.",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 24,
                Content = "Let's plan a potluck dinner!",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 25,
                Content = "I'm in! I'll bring my famous lasagna.",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 26,
                Content = "Sounds delicious! I'll make guacamole.",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 27,
                Content = "Count me in too! I'll bring dessert.",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 28,
                Content = "Have you read any good books lately?",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 29,
                Content = "I just finished a fantastic mystery novel.",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 30,
                Content = "I'm into science fiction. Any recommendations?",
                SubGroupId = 1,
                UserId = 3
            } ,
            new MessageEntity
            {
                Id = 31,
                Content = "Let's organize a hiking trip next month.",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 32,
                Content = "That sounds like a great idea! I'm in!",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 33,
                Content = "Count me in too! I love nature hikes.",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 34,
                Content = "What's your favorite hiking trail?",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 35,
                Content = "I enjoy trails with scenic views and waterfalls.",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 36,
                Content = "I prefer challenging mountain trails. The more difficult, the better!",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 37,
                Content = "Have you tried rock climbing before?",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 38,
                Content = "Yes, it's an adrenaline rush! Highly recommend it.",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 39,
                Content = "Rock climbing sounds exciting. I'll give it a try!",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 40,
                Content = "What's your favorite season for outdoor activities?",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 41,
                Content = "I love the fall season. The weather is perfect for hiking.",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 42,
                Content = "Summer is my favorite. Beach days and outdoor events!",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 43,
                Content = "Let's plan a beach day soon.",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 44,
                Content = "I'm in! I miss the sound of ocean waves.",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 45,
                Content = "Count me in too! I'll bring the beach games.",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 46,
                Content = "Have you ever tried scuba diving?",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 47,
                Content = "Not yet, but it's on my bucket list!",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 48,
                Content = "I've been scuba diving in some amazing locations.",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 49,
                Content = "Let's plan a game night with board games and snacks.",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 50,
                Content = "I'm in! I have a collection of board games at home.",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 51,
                Content = "Count me in too! I'll bring some homemade snacks.",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 52,
                Content = "Do you have any favorite board games?",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 53,
                Content = "I enjoy strategy games like Settlers of Catan.",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 54,
                Content = "I love party games like Codenames. Always so much fun!",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 55,
                Content = "Let's share our favorite music playlists.",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 56,
                Content = "I'm into indie rock. What about you?",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 57,
                Content = "I enjoy a mix of genres, but electronic music is my favorite.",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 58,
                Content = "Have you ever attended a music festival?",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 59,
                Content = "Yes, the energy and live performances are unforgettable!",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 60,
                Content = "I've been to a few. It's a unique experience every time.",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 61,
                Content = "Let's plan a weekend getaway to the mountains.",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 62,
                Content = "I'm in! A cabin in the woods sounds perfect.",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 63,
                Content = "Count me in too! I love the serenity of the mountains.",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 64,
                Content = "What's your favorite travel destination?",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 65,
                Content = "I love exploring European cities and their rich history.",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 66,
                Content = "Beach destinations are my favorite. I love the sun and sand.",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 67,
                Content = "Let's plan a photography day and capture the beauty around us.",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 68,
                Content = "Great idea! I'll bring my camera and some lenses.",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 69,
                Content = "Count me in too! I love photography.",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 70,
                Content = "Do you prefer digital or film photography?",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 71,
                Content = "I love the convenience of digital photography.",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 72,
                Content = "Film photography has a unique charm. I enjoy both.",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 73,
                Content = "Let's try a new restaurant together. Any cuisine preferences?",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 74,
                Content = "I'm a fan of Italian cuisine. Pasta and pizza are my weaknesses.",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 75,
                Content = "I love exploring different cuisines. Surprise me!",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 76,
                Content = "Have you ever participated in a charity run or walk?",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 77,
                Content = "Yes, it's a great way to stay active and contribute to a cause.",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 78,
                Content = "I've been part of a few. It's fulfilling to make a difference.",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 79,
                Content = "Let's plan a weekend brunch. Any favorite brunch spots?",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 80,
                Content = "I know a cozy café with the best brunch menu!",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 81,
                Content = "I'm up for brunch! Let's try something new and exciting.",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 82,
                Content = "What's your go-to workout routine?",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 83,
                Content = "I enjoy a mix of cardio and strength training.",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 84,
                Content = "Yoga is my go-to. It keeps me balanced and relaxed.",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 85,
                Content = "Let's plan a movie night. Any genre preferences?",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 86,
                Content = "I love sci-fi movies. The more futuristic, the better!",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 87,
                Content = "I enjoy a good comedy. Laughter is the best medicine.",
                SubGroupId = 1,
                UserId = 3
            },
            new MessageEntity
            {
                Id = 88,
                Content = "Have you ever tried bungee jumping or skydiving?",
                SubGroupId = 1,
                UserId = 1
            },
            new MessageEntity
            {
                Id = 89,
                Content = "Not yet, but it's on my adventure bucket list!",
                SubGroupId = 1,
                UserId = 2
            },
            new MessageEntity
            {
                Id = 90,
                Content = "I've tried both. The adrenaline rush is indescribable!",
                SubGroupId = 1,
                UserId = 3
            }


            // Continue adding the remaining messages
        );
    }

}
