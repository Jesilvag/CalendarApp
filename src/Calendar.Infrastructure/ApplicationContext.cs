using Calendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Infrastructure
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
