using Gdc.Api.Modeles;
using Microsoft.EntityFrameworkCore;

namespace GDE.Api.Datas
{
    public class CourDbContext: DbContext
    {
        public CourDbContext(DbContextOptions<CourDbContext> options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntite>())
            {
                entry.Entity.DateDerniereModification = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreation = DateTime.Now;
                }
                    
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourDbContext).Assembly);
        }

        public DbSet<CoursGenerique> CoursGeneriques { get; set; }
        public DbSet<Matiere> Matieres { get; set; }
        public DbSet<Niveau> Niveaux { get; set; }
        public DbSet<Enseignant> Enseignants { get; set; }
    }
}
