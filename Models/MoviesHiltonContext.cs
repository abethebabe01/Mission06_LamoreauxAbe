using Microsoft.EntityFrameworkCore;

namespace Mission06_LamoreauxAbe.Models
{
    public class MoviesHiltonContext : DbContext
    {
        public MoviesHiltonContext(DbContextOptions<MoviesHiltonContext> options) : base(options)
        {
        }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // this is for the seed data.
        {
            modelBuilder.Entity<Categories>().HasData(

                new Categories { CategoryId = 41, Category = "Fortnite" },
                new Categories { CategoryId = 42, Category = "BattlePass" }

                );
        }
    }
}
