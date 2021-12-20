using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebShop.Domain.Models;

namespace WebShopDbContect
{
    public partial class WebShopContext : DbContext
    {
        public WebShopContext()
        {
        }

        public WebShopContext(DbContextOptions<WebShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductType> ProductTypes { get; set; } = null!;
        public virtual DbSet<Reference> References { get; set; } = null!;
        public virtual DbSet<ReferenceType> ReferenceTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=UNKNOWN\\LOCALHOST;Initial Catalog=WebShop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("Manufacturer");

                entity.Property(e => e.ManufacturerId)
                    .ValueGeneratedNever()
                    .HasColumnName("Manufacturer_Id");

                entity.Property(e => e.CommercialName).HasMaxLength(250);

                entity.Property(e => e.ContactEmail).HasMaxLength(100);

                entity.Property(e => e.ContactPhone).HasMaxLength(30);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("Product_Id");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.ManufacturerId).HasColumnName("Manufacturer_Id");

                entity.Property(e => e.Price).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductType_Id");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK_Product_Manufacturer");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeId)
                    .HasConstraintName("FK_Product_ProductType");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("ProductType");

                entity.Property(e => e.ProductTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductType_Id");

                entity.Property(e => e.AdditionalCode)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Reference>(entity =>
            {
                entity.ToTable("Reference");

                entity.Property(e => e.ReferenceId)
                    .ValueGeneratedNever()
                    .HasColumnName("Reference_Id");

                entity.Property(e => e.AdditionalCode)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.ReferenceTypeId).HasColumnName("ReferenceType_Id");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.ReferenceType)
                    .WithMany(p => p.References)
                    .HasForeignKey(d => d.ReferenceTypeId)
                    .HasConstraintName("FK_Reference_Reference");
            });

            modelBuilder.Entity<ReferenceType>(entity =>
            {
                entity.ToTable("ReferenceType");

                entity.Property(e => e.ReferenceTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("ReferenceType_Id");

                entity.Property(e => e.AdditionalCode)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
