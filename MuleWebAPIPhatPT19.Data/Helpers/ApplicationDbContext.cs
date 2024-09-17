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
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchaseorder> PurchaseOrders { get; set; }
        public DbSet<Purchaseorderdetail> PurchaseOrderDetails { get; set; }
        public DbSet<Salesorder> SalesOrders { get; set; }
        public DbSet<Salesorderdetail> SalesOrderDetails { get; set; }

        // Override OnModelCreating to configure primary keys and relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure composite keys
            modelBuilder.Entity<Account>()
                .HasKey(p => new { p.FldAccount});            
            
            modelBuilder.Entity<Product>()
                .HasKey(p => new { p.ProductCode});

            modelBuilder.Entity<Purchaseorder>()
                .HasKey(p => new { p.OrderNo, p.OrderDate });

            modelBuilder.Entity<Purchaseorderdetail>()
                .HasKey(p => new { p.OrderNo, p.ProductCode, p.PurchasePrice });

            modelBuilder.Entity<Salesorder>()
                .HasKey(s => new { s.OrderNo, s.OrderDate });

            modelBuilder.Entity<Salesorderdetail>()
                .HasKey(s => new { s.OrderNo, s.ProductCode, s.SalesPrice });

            // Additional configuration like relationships can be added here
        }
    }
}
