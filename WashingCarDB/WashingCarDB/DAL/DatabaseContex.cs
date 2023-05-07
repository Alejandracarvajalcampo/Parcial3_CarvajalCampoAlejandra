using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WashingCarDB.DAL.Entities
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Service> Services { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleDetail> VehiclesDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Service>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Vehicle>().HasIndex(c => c.NumberPlate).IsUnique();
            modelBuilder.Entity<VehicleDetail>().HasIndex(c => c.Id).IsUnique();

        }
    }

}
