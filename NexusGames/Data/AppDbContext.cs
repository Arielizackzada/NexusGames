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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add DbSet<TEntity> properties here, for example:
        // public DbSet<YourEntity> YourEntities { get; set; }
    }
}
