using Microsoft.EntityFrameworkCore;

namespace TeamService.Models
{
    public class TeamContext : DbContext
    {
        public TeamContext(DbContextOptions<TeamContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}
