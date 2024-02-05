using WebChat.Presistence.SeedConfiguration;

namespace WebChat.Presistence.DBContext;

public class WebchatDBContext(DbContextOptions<WebchatDBContext> options) : DbContext(options), IWebchatDBContext
{
    public DbSet<UserEntity> User { get ; set ; }
    public DbSet<GroupEntitiy> Group { get; set; }
    public DbSet<MessageEntity> Message { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new GroupConfiguration());
        modelBuilder.ApplyConfiguration(new MessageConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }

}
