using case_application.Domain;
using Microsoft.EntityFrameworkCore;

namespace case_application.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Device> Devices => Set<Device>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>()
                .HasIndex(d => d.SerialNumber)
                .IsUnique();
        }
    }
}
