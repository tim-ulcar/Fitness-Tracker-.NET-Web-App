using web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace web.Data
{
    public class FitnessTrackerContext : IdentityDbContext<ApplicationUser>
    {
        public FitnessTrackerContext(DbContextOptions<FitnessTrackerContext> options) : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExercisePerformed> ExercisesPerformed { get; set; }
        public DbSet<BodyWeight> BodyWeights { get; set; }
        public DbSet<Nutrition> Nutritions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*
            modelBuilder.Entity<ExercisePerformed>().HasKey(c => new { c.userId, c.exerciseId, c.time });
            modelBuilder.Entity<BodyWeight>().HasKey(c => new { c.userId, c.time });
            modelBuilder.Entity<Nutrition>().HasKey(c => new { c.userId, c.time });
            */

            modelBuilder.Entity<Exercise>().ToTable("Exercise");
            modelBuilder.Entity<ExercisePerformed>().ToTable("ExercisePerformed");
            modelBuilder.Entity<BodyWeight>().ToTable("BodyWeight");
            modelBuilder.Entity<Nutrition>().ToTable("Nutrition");
        }
    }
}