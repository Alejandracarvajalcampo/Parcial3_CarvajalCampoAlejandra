using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace WashingCarDB.DAL.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Services> Countries { get; set; }
        public DbSet<Vehicles> Categories { get; set; }
        public DbSet<VehicleDetails> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Services>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Vehicles>().HasIndex(c => c.NumberPlate).IsUnique();

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