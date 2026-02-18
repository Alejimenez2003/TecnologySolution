using Microsoft.EntityFrameworkCore;

namespace DA.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // TODO: Add DbSet<T> properties for your entities, for example:
        // public DbSet<Model.YourEntity> YourEntities { get; set; }
    }
}
