using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ElsaConcept.Models;

namespace ElsaConcept.Data
{
    public class ElsaConceptContext : DbContext
    {
        public ElsaConceptContext (DbContextOptions<ElsaConceptContext> options)
            : base(options)
        {
        }

        public DbSet<ElsaConcept.Models.User> User { get; set; }
        public DbSet<ElsaConcept.Models.Stock> Stock { get; set; }

        public DbSet<ElsaConcept.Models.Product> Product { get; set; }
        public DbSet<ElsaConcept.Models.StockMov> StockMov { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

    }
}
