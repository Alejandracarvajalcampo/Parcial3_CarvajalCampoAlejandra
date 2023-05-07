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
        public DbSet<Services> Services { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<VehicleDetails> VehiclesDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Services>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Vehicles>().HasIndex(c => c.NumberPlate).IsUnique();
            modelBuilder.Entity<VehicleDetails>().HasIndex(c => c.Id).IsUnique();

        }
    }

}






//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        base.OnModelCreating(modelBuilder);
//        modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
//        modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
//        modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique(); // índices compuestos
//        modelBuilder.Entity<City>().HasIndex("Name", "StateId").IsUnique(); // índices compuestos
//    }
//}
//}