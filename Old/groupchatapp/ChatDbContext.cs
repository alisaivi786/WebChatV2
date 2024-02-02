using GroupChatApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
public class ChatDbContext : DbContext
{
    public DbSet<Group> Groups { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }

    public ChatDbContext()
    {
    }

    public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=GroupChatDB;Trusted_Connection=True;MultipleActiveResultSets=true");
}