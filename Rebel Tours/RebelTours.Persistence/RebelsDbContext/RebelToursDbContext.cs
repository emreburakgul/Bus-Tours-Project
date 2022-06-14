using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RebelTours.Domain;
using RebelTours.Persistence.Configrations;

namespace RebelTours.Persistence.RebelsDbContext
{
   public class RebelToursDbContext : DbContext
    {
        private const string ConnectionString = "Server=.; Database=RebelToursDbW; User=sa;Password=12345;";

        public DbSet<City> Cities { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<BusManufacturer> BusManufacturers { get; set; }
        public DbSet<BusModel> BusModels { get; set; }
        public DbSet<Bus> Buses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CityConfig());
            modelBuilder.ApplyConfiguration(new StationConfig());
            modelBuilder.ApplyConfiguration(new BusManufacturerConfig());
            modelBuilder.ApplyConfiguration(new BusModelConfig());
            modelBuilder.ApplyConfiguration(new BusConfig());


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
