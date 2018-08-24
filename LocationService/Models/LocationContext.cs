using Microsoft.EntityFrameworkCore;

namespace LocationService.Models
{
    public class LocationContext : DbContext
    {
        public LocationContext(DbContextOptions<LocationContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<LocationRecord> LocationRecords { get; set; }
    }
}
