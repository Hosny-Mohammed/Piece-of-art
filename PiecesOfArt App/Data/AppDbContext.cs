using Microsoft.EntityFrameworkCore;
using PiecesOfArt_App.Models;

namespace PiecesOfArt_App.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Art>().HasIndex(x => x.Title).IsUnique();

            modelBuilder.Entity<User>().HasData(
    new User { Id = 1, Name = "Alex Johnson", Email = "alex.johnson@example.com", Age = 28, loyaltyCardId = 1 },
    new User { Id = 2, Name = "Bethany Green", Email = "bethany.green@example.com", Age = 32, loyaltyCardId = 2 },
    new User { Id = 3, Name = "Charlie Brown", Email = "charlie.brown@example.com", Age = 24, loyaltyCardId = 1 },
    new User { Id = 4, Name = "Diana Prince", Email = "diana.prince@example.com", Age = 30, loyaltyCardId = 3 },
    new User { Id = 5, Name = "Ethan Hunt", Email = "ethan.hunt@example.com", Age = 35, loyaltyCardId = 2 }
);

            modelBuilder.Entity<Art>().HasData(
                new Art { Id = 1, Title = "Sunset Bliss", PublicationDate = new DateOnly(2022, 10, 5), Description = "A beautiful sunset painting.", userID = 1, categoryID = 1 },
                new Art { Id = 2, Title = "Mountain Majesty", PublicationDate = new DateOnly(2021, 7, 15), Description = "An awe-inspiring mountain landscape.", userID = 2, categoryID = 2 },
                new Art { Id = 3, Title = "City Lights", PublicationDate = new DateOnly(2023, 3, 22), Description = "A vibrant city at night.", userID = 3, categoryID = 1 },
                new Art { Id = 4, Title = "Ocean Waves", PublicationDate = new DateOnly(2020, 6, 8), Description = "The calming waves of the ocean.", userID = 4, categoryID = 3 },
                new Art { Id = 5, Title = "Forest Path", PublicationDate = new DateOnly(2019, 11, 2), Description = "A serene path through the forest.", userID = 5, categoryID = 2 }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Landscapes", Description = "Art depicting natural scenery" },
                new Category { Id = 2, Name = "Urban", Description = "Art depicting cityscapes" },
                new Category { Id = 3, Name = "Seascapes", Description = "Art depicting the sea" }
            );

            modelBuilder.Entity<LoyaltyCard>().HasData(
                new LoyaltyCard { Id = 1, Name = "Gold Membership", Description = "Top-tier membership with exclusive benefits" },
                new LoyaltyCard { Id = 2, Name = "Silver Membership", Description = "Mid-tier membership with many benefits" },
                new LoyaltyCard { Id = 3, Name = "Bronze Membership", Description = "Basic membership with standard benefits" }
            );

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Art> Arts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<LoyaltyCard> LoyaltyCards { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
