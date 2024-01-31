namespace WebChat.Presistence.DBContext;

public class WebchatDBContext(DbContextOptions<WebchatDBContext> options) : DbContext(options), IWebchatDBContext
{
    public DbSet<UserEntity> User { get ; set ; }
    public DbSet<GroupEntitiy> Group { get; set; }
    public DbSet<MessageEntity> Message { get; set; }
    public DbSet<GroupUsersEntity> GroupUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseLazyLoadingProxies(); // Enable lazy loading
        base.OnConfiguring(optionsBuilder);
    }

}
