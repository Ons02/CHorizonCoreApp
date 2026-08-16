using CH_Manage.Models;
using Microsoft.EntityFrameworkCore;

namespace CH_Manage.EF_Configurations
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<ClientConfiguration> ClientConfigurations { get; set; }
        public DbSet<ConfigurationOption> ConfigurationOptions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
