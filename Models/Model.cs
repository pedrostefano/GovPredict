using Microsoft.EntityFrameworkCore;

namespace GovPredict.Models
{
  public class GovPredictContext : DbContext
  {
    public DbSet<Post> Posts { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<List> Lists { get; set; }
    public DbSet<UserList> UserLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=data.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<UserList>().HasKey(ul => new { ul.UserId, ul.ListId });
      modelBuilder.Entity<UserList>()
          .HasOne<User>(sc => sc.User)
          .WithMany(s => s.UserLists)
          .HasForeignKey(sc => sc.UserId);


      modelBuilder.Entity<UserList>()
          .HasOne<List>(sc => sc.List)
          .WithMany(s => s.UserLists)
          .HasForeignKey(sc => sc.ListId);


    }

  }
}