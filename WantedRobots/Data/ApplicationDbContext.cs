// ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using WantedRobots.Models;


namespace WantedRobots.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Robot> Robots { get; set; }
        public DbSet<DeletedRobot> DeletedRobots { get; set; }
        public DbSet<Agent> Agents { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Utilisez Fluent API pour définir le nom de la table, si nécessaire.
            modelBuilder.Entity<Robot>().ToTable("Robots");

            // Définissez des contraintes, des index, etc. ici si nécessaire.

            base.OnModelCreating(modelBuilder);
        }
    }

}
