using Microsoft.EntityFrameworkCore;
using NexusGames.Models;
using System.Collections.Generic;


namespace NexusGames.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Gamer> Gamers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action" },
                new Category { Id = 2, Name = "Adventure" },
                new Category { Id = 3, Name = "RPG" },
                new Category { Id = 4, Name = "Strategy" },
                new Category { Id = 5, Name = "Simulation" },
                new Category { Id = 6, Name = "Sports" },
                new Category { Id = 7, Name = "Puzzle" },
                new Category { Id = 8, Name = "Horror" },
                new Category { Id = 9, Name = "MMO" },
                new Category { Id = 10, Name = "Indie" },
                new Category { Id = 11, Name = "Racing" },
                new Category { Id = 12, Name = "Fighting" },
                new Category { Id = 13, Name = "Platformer" },
                new Category { Id = 14, Name = "Shooter" },
                new Category { Id = 15, Name = "Strategy" }
            );
        }
    }

}
 