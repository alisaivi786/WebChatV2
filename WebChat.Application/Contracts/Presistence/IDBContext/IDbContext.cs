namespace WebChat.Application.Contracts.Presistence.IDBContext;

public interface IDbContext
{
    public DbSet<UserEntity> User { get; set; }
    public DbSet<GroupEntitiy> Group { get; set; }
    public DbSet<MessageEntity> Message { get; set; }
    public DbSet<GroupUsersEntity> GroupUsers { get; set; }
}
