using Microsoft.EntityFrameworkCore;
using WebApiHumanModels.Data;

namespace WebApiHuman.Data
{
    public class HumanContext: DbContext
    {
        public DbSet<Human> Humans { get; set; }

        public HumanContext(DbContextOptions<HumanContext> options)
        : base(options)
        {
        }

        public void RefreshAll()
        {
            foreach (var entity in ChangeTracker.Entries())
            {
                entity.Reload();
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Human>().ToTable("Humans");
        }

    }
}
