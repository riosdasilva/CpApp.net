using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CpApp.Models;

namespace CpApp.Data
{
    public class CpAppContext : DbContext
    {
        public CpAppContext (DbContextOptions<CpAppContext> options)
            : base(options)
        {
        }

        public DbSet<CpApp.Models.User> User { get; set; }
        public DbSet<CpApp.Models.Client> Client { get; set; }
        public DbSet<CpApp.Models.Inspector> Inspector { get; set; }
        public DbSet<CpApp.Models.CreditCard> CreditCard { get; set; }
        public DbSet<CpApp.Models.Review> Review { get; set; }
        public DbSet<CpApp.Models.Seat> Seat { get; set; }
        public DbSet<CpApp.Models.Station> Station { get; set; }
        public DbSet<CpApp.Models.Stop> Stop { get; set; }
        public DbSet<CpApp.Models.Ticket> Ticket { get; set; }
        public DbSet<CpApp.Models.Trip> Trip { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Station>().HasMany(t => t.TripsI)
                .WithOne(g => g.InitialStation)
                .HasForeignKey(g => g.InitialStationId);
            modelBuilder.Entity<Station>().HasMany(t => t.TripsF)
                .WithOne(g => g.FinalStation)
                .HasForeignKey(g => g.FinalStationId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Station>().HasMany(t => t.StopsC)
               .WithOne(g => g.CurrentStation)
               .HasForeignKey(g => g.CurrentStationId);
            modelBuilder.Entity<Station>().HasMany(t => t.StopsF)
                .WithOne(g => g.NextStation)
                .HasForeignKey(g => g.NextStationId).OnDelete(DeleteBehavior.Restrict);
        }

    }
}
