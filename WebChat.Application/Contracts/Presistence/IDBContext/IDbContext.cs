namespace WebChat.Application.Contracts.Presistence.IDBContext;

#region IDbContext Contract
#region IDbContext Contract Summary
/// <summary>
/// IDbContext Contract
/// Developer: ALI RAZA MUSHTAQ
/// Date: 05-Feb-2024
/// alisaivi786@gmail.com
/// </summary> 
#endregion
public interface IDbContext
{
    public DbSet<UserDetailsEntity> UserDetails { get; set; }
    public DbSet<GroupEntity> Group { get; set; }
    public DbSet<SubGroupEntity> SubGroup { get; set; }
    public DbSet<MessageEntity> Message { get; set; }
    public DbSet<GroupUsersEntity> GroupUsers { get; set; }
    public DbSet<LoginInUserEntity> LoginInUser { get; set; }
}

#endregion