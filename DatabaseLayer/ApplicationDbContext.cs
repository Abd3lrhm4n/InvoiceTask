using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<ItemDetials> ItemDetials { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemDetials>()
                        .Property(d => d.Price)
                        .HasColumnType("decimal(9, 2)");

            modelBuilder.Entity<InvoiceDetails>()
                        .Property(d => d.Price)
                        .HasColumnType("decimal(9, 2)");
            modelBuilder.Entity<InvoiceDetails>()
                        .Property(d => d.Total)
                        .HasColumnType("decimal(9, 2)");
            modelBuilder.Entity<InvoiceDetails>()
                        .Property(d => d.Net)
                        .HasColumnType("decimal(9, 2)");
            modelBuilder.Entity<InvoiceDetails>()
                        .Property(d => d.Discount)
                        .HasColumnType("decimal(9, 2)");

            modelBuilder.Entity<Invoice>()
                        .Property(d => d.Total)
                        .HasColumnType("decimal(9, 2)");
            modelBuilder.Entity<Invoice>()
                        .Property(d => d.Net)
                        .HasColumnType("decimal(9, 2)");
            modelBuilder.Entity<Invoice>()
                        .Property(d => d.Tax)
                        .HasColumnType("decimal(9, 2)");

            modelBuilder.Entity<ItemDetials>()
                .HasKey(c => new { c.ItemId, c.UnitId });

            base.OnModelCreating(modelBuilder);
        }

    }
}
