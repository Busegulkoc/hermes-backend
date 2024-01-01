global using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){

        }
        public DbSet<traveler> Travelers => Set<traveler>();
        public DbSet<Tour> Tours => Set<Tour>();
        public DbSet<Admin> Admin => Set<Admin>();
        public DbSet<CityCountry> CityCountry => Set<CityCountry>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Hotel> Hotels => Set<Hotel>();
        public DbSet<Manager> Manager => Set<Manager>();
        public DbSet<TransportationVehicle> TransportationVehicle => Set<TransportationVehicle>();
        public DbSet<TransportationWorkers> TransportationWorkers => Set<TransportationWorkers>();
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<traveler>()
                .HasMany(t => t.Tours)
                .WithMany(t => t.TravelerList)
                .UsingEntity(j => j.ToTable("TravelerTours"));

            modelBuilder.Entity<traveler>()
                .HasMany(t => t.favoriteTours)
                .WithMany()
                .UsingEntity(j => j.ToTable("TravelerFavoriteTours"));
        }
    }
}