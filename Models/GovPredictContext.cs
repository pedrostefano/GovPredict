using System;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace GovPredict.Models
{
  public class GovPredictContext : DbContext
  {
    public DbSet<Post> Posts { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<SocialNetwork> SocialNetworks { get; set; }
    public DbSet<List> Lists { get; set; }
    public DbSet<UserList> UserLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=./Data/data.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<UserList>()
        .HasKey(ul => new { ul.UserId, ul.ListId });

      modelBuilder.Entity<UserList>()
        .HasOne<User>(sc => sc.User)
        .WithMany(s => s.UserLists)
        .HasForeignKey(sc => sc.UserId);

      modelBuilder.Entity<UserList>()
        .HasOne<List>(sc => sc.List)
        .WithMany(s => s.UserLists)
        .HasForeignKey(sc => sc.ListId);

      Seed(modelBuilder);

    }

    private void Seed(ModelBuilder modelBuilder)
    {

      modelBuilder.Entity<SocialNetwork>().HasData(
          new SocialNetwork { Id = 1, Name = "Facebook" },
          new SocialNetwork { Id = 2, Name = "Twitter" }
      );

      modelBuilder.Entity<User>().HasData(
        new User { Id = 1, Name = "Pedro" },
        new User { Id = 2, Name = "Maria Júlia" },
        new User { Id = 3, Name = "João" }
      );

      modelBuilder.Entity<List>().HasData(
        new List { Id = 1, Name = "Fast" },
        new List { Id = 2, Name = "Cool" },
        new List { Id = 3, Name = "Amazing" }
      );

      modelBuilder.Entity<UserList>().HasData(
        new UserList { UserId = 1, ListId = 1 },
        new UserList { UserId = 1, ListId = 2 },
        new UserList { UserId = 1, ListId = 3 },
        new UserList { UserId = 2, ListId = 2 },
        new UserList { UserId = 2, ListId = 3 },
        new UserList { UserId = 3, ListId = 1 }
      );

      modelBuilder.Entity<Account>().HasData(
        new Account { Id = 1, Name = "pedro", SocialNetworkId = 1, UserId = 1 },
        new Account { Id = 2, Name = "pedrostefano", SocialNetworkId = 1, UserId = 1 },
        new Account { Id = 3, Name = "pedrostefanotoffalini", SocialNetworkId = 2, UserId = 1 },
        new Account { Id = 4, Name = "maria", SocialNetworkId = 1, UserId = 2 },
        new Account { Id = 5, Name = "mariaju", SocialNetworkId = 2, UserId = 2 },
        new Account { Id = 6, Name = "joao", SocialNetworkId = 1, UserId = 3 },
        new Account { Id = 7, Name = "j", SocialNetworkId = 2, UserId = 3 },
        new Account { Id = 8, Name = "joooaaaooo", SocialNetworkId = 2, UserId = 3 }
      );

      var faker = new Faker("en");
      Randomizer.Seed = new Random(123456);

      for (var i = 1; i < 1000; i++)
      {
        modelBuilder.Entity<Post>().HasData(
          new Post()
          {
            Id = i,
            Content = faker.Lorem.Sentence(3, 50),
            Link = faker.Internet.Url(),
            Date = faker.Date.Between(DateTime.Now.AddYears(-1), DateTime.Now.AddMonths(2)),
            AccountId = faker.Random.Number(1, 8)
          });
      }
    }
  }


}