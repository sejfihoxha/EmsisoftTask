using Microsoft.EntityFrameworkCore;

namespace EmsisoftTask.Data.EntityFramework
{
    public class EmsisoftTaskDbContext : DbContext
    {
        public EmsisoftTaskDbContext(DbContextOptions<EmsisoftTaskDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmsisoftTaskDbContext).Assembly);
        }
    }
}
