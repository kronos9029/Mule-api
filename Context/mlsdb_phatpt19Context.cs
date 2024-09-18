using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MuleWebAPIPhatPT19.Data.Models.Entities;

namespace MuleWebAPIPhatPT19.Data.Context
{
    public partial class mlsdb_phatpt19Context : DbContext
    {
        public mlsdb_phatpt19Context()
        {
        }

        public mlsdb_phatpt19Context(DbContextOptions<mlsdb_phatpt19Context> options)
            : base(options)
        {
        }

        public virtual DbSet<product> Products { get; set; } = null!;
        public virtual DbSet<purchaseorder> Purchaseorders { get; set; } = null!;
        public virtual DbSet<purchaseorderdetail> Purchaseorderdetails { get; set; } = null!;
        public virtual DbSet<salesorder> Salesorders { get; set; } = null!;
        public virtual DbSet<salesorderdetail> Salesorderdetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=junction.proxy.rlwy.net; port=45448; database=railway; user=root; password=TbgchNdWXBhdAxWVsqOwLsMVBczeoCjh; Persist Security Info=False; Convert Zero Datetime=True;Allow Zero Datetime=True; Connect Timeout=300;Charset=utf8", ServerVersion.Parse("9.0.1-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<product>(entity =>
            {
                entity.HasKey(e => new { e.ProductCode })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("products");

                entity.Property(e => e.ProductCode).HasMaxLength(6);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedByDate).HasDefaultValueSql("'2024-01-01'");

                entity.Property(e => e.ProductName).HasMaxLength(150);

                entity.Property(e => e.QuantityInStock).HasDefaultValueSql("'0'");

                entity.Property(e => e.Unit).HasMaxLength(20);
            });

            modelBuilder.Entity<purchaseorder>(entity =>
            {
                entity.HasKey(e => new { e.OrderNo, e.OrderDate })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("purchaseorders");

                entity.Property(e => e.OrderNo).HasMaxLength(6);

                entity.Property(e => e.OrderDate).HasDefaultValueSql("'2024-01-01'");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedByDate).HasDefaultValueSql("'2024-01-01'");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<purchaseorderdetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderNo, e.ProductCode, e.PurchasePrice })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("purchaseorderdetails");

                entity.Property(e => e.OrderNo).HasMaxLength(6);

                entity.Property(e => e.ProductCode).HasMaxLength(6);

                entity.Property(e => e.Quantity).HasDefaultValueSql("'0'");

                entity.Property(e => e.Tax).HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<salesorder>(entity =>
            {
                entity.HasKey(e => new { e.OrderNo, e.OrderDate })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("salesorders");

                entity.Property(e => e.OrderNo).HasMaxLength(6);

                entity.Property(e => e.OrderDate).HasDefaultValueSql("'2024-01-01'");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedByDate).HasDefaultValueSql("'2024-01-01'");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<salesorderdetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderNo, e.ProductCode, e.SalesPrice })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("salesorderdetails");

                entity.Property(e => e.OrderNo).HasMaxLength(6);

                entity.Property(e => e.ProductCode).HasMaxLength(6);

                entity.Property(e => e.Quantity).HasDefaultValueSql("'0'");

                entity.Property(e => e.Tax).HasDefaultValueSql("'0'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
