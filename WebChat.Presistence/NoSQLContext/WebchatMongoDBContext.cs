using MongoDB.Driver;

namespace WebChat.Presistence.NoSQLContext;

public class WebchatMongoDBContext(IMongoDatabase database) : DbContext, IWebchatMongoDBContext
{
    private readonly IMongoDatabase _database = database;

    public DbSet<UserDetailsEntity> UserDetails { get; set; }
    public DbSet<GroupEntity> Group { get; set; }
    public DbSet<SubGroupEntity> SubGroup { get; set; }
    public DbSet<MessageEntity> Message { get; set; }
    public DbSet<GroupUsersEntity> GroupUsers { get; set; }
    public DbSet<LoginInUserEntity> LoginInUser { get; set; }

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