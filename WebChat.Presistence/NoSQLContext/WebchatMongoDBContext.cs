using MongoDB.Driver;

namespace WebChat.Presistence.NoSQLContext;

public class WebchatMongoDBContext(IMongoDatabase database) : DbContext, IWebchatMongoDBContext
{
    private readonly IMongoDatabase _database = database;

    public DbSet<UserEntity> User { get; set; }
    public DbSet<GroupEntitiy> Group { get; set; }
    public DbSet<MessageEntity> Message { get; set; }
    public DbSet<GroupUsersEntity> GroupUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // In MongoDB, the connection is handled by the IMongoDatabase instance
        // No need to configure optionsBuilder for MongoDB
    }
}