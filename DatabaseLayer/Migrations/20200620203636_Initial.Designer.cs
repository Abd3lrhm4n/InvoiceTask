﻿// <auto-generated />
using System;
using DatabaseLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatabaseLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200620203636_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DatabaseLayer.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("InvoiceNo");

                    b.Property<decimal>("Net")
                        .HasColumnType("decimal(9, 2)");

                    b.Property<int>("StoreId");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(3, 2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(9, 2)");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("DatabaseLayer.InvoiceDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(3, 2)");

                    b.Property<int>("ItemId");

                    b.Property<decimal>("Net")
                        .HasColumnType("decimal(9, 2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(9, 2)");

                    b.Property<double>("Quantity");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(9, 2)");

                    b.Property<int>("UnitId");

                    b.HasKey("Id");

                    b.ToTable("InvoiceDetails");
                });

            modelBuilder.Entity("DatabaseLayer.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ItemName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("DatabaseLayer.ItemDetials", b =>
                {
                    b.Property<int>("ItemId");

                    b.Property<int>("UnitId");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(9, 2)");

                    b.HasKey("ItemId", "UnitId");

                    b.HasIndex("UnitId");

                    b.ToTable("ItemDetials");
                });

            modelBuilder.Entity("DatabaseLayer.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StoreName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("DatabaseLayer.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<string>("UnitName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("DatabaseLayer.ItemDetials", b =>
                {
                    b.HasOne("DatabaseLayer.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DatabaseLayer.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DatabaseLayer.Unit", b =>
                {
                    b.HasOne("DatabaseLayer.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
