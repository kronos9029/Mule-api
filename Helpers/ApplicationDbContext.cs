using Microsoft.EntityFrameworkCore;
using MuleWebAPIPhatPT19.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuleWebAPIPhatPT19.Data.Helpers
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Define DbSet for each entity (table)
        public DbSet<product> Products { get; set; }
        public DbSet<purchaseorder> PurchaseOrders { get; set; }
        public DbSet<purchaseorderdetail> PurchaseOrderDetails { get; set; }
        public DbSet<salesorder> SalesOrders { get; set; }
        public DbSet<salesorderdetail> SalesOrderDetails { get; set; }

        // Override OnModelCreating to configure primary keys and relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure composite keys         
            
            modelBuilder.Entity<product>()
                .HasKey(p => new { p.ProductCode});

            modelBuilder.Entity<purchaseorder>()
                .HasKey(p => new { p.OrderNo, p.OrderDate });

            modelBuilder.Entity<purchaseorderdetail>()
                .HasKey(p => new { p.OrderNo, p.ProductCode, p.PurchasePrice });

            modelBuilder.Entity<salesorder>()
                .HasKey(s => new { s.OrderNo, s.OrderDate });

            modelBuilder.Entity<salesorderdetail>()
                .HasKey(s => new { s.OrderNo, s.ProductCode, s.SalesPrice });

            // Additional configuration like relationships can be added here
        }
    }
}
