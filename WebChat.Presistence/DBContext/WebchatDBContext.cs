namespace WebChat.Presistence.DBContext;

public class WebchatDBContext(DbContextOptions<WebchatDBContext> options) : DbContext(options), IWebchatDBContext
{
    public DbSet<UserDetailsEntity> UserDetails { get; set; }
    public DbSet<GroupUsersEntity> GroupUsers { get; set; }
    public DbSet<GroupEntity> Group { get; set; }
    public DbSet<SubGroupEntity> SubGroup { get; set; }
    public DbSet<MessageEntity> Message { get; set; }
    public DbSet<LoginInUserEntity> LoginInUser { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new GroupConfiguration());
        modelBuilder.ApplyConfiguration(new MessageConfiguration());
        modelBuilder.ApplyConfiguration(new SubGroupConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }

}
