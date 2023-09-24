using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Project.Models;

public partial class ECommerceProjectContext : DbContext
{
    public ECommerceProjectContext()
    {
    }

    public ECommerceProjectContext(DbContextOptions<ECommerceProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderTable> OrderTables { get; set; }

    public virtual DbSet<Postal> Postals { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-2SEFI52\\SQLEXPRESS;Initial Catalog=E_Commerce_Project;Integrated Security=True;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A2B8FF2C474");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(65)
                .IsUnicode(false);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__City__F2D21B76FCBE65D1");

            entity.ToTable("City");

            entity.Property(e => e.CityName)
                .HasMaxLength(55)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8813A4F79");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.CustomerPassword)
                .HasMaxLength(55)
                .IsUnicode(false);

            entity.HasOne(d => d.CustomerCityNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustomerCity)
                .HasConstraintName("FK__Customer__Custom__4316F928");

            entity.HasOne(d => d.CustomerPostalCodeNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustomerPostalCode)
                .HasConstraintName("FK__Customer__Custom__440B1D61");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D30CA5F68B6B");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductPrice).HasColumnType("decimal(9, 3)");
            entity.Property(e => e.SubTotal).HasColumnType("decimal(9, 3)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__Order__4AB81AF0");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderDeta__Produ__49C3F6B7");
        });

        modelBuilder.Entity<OrderTable>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__OrderTab__C3905BAF5CF73235");

            entity.ToTable("OrderTable");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.IsDelivered)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("is_delivered");
            entity.Property(e => e.OrderDate).HasColumnType("date");
            entity.Property(e => e.OrderTotal).HasColumnType("decimal(9, 3)");
            entity.Property(e => e.ShippingDate).HasColumnType("date");

            entity.HasOne(d => d.Customer).WithMany(p => p.OrderTables)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__OrderTabl__Custo__46E78A0C");
        });

        modelBuilder.Entity<Postal>(entity =>
        {
            entity.HasKey(e => e.PostalCode).HasName("PK__Postal__12D1DBD3FC298087");

            entity.ToTable("Postal");

            entity.Property(e => e.PostalCode).ValueGeneratedNever();
            entity.Property(e => e.PostalArea)
                .HasMaxLength(55)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6EDE73183B1");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("ProductID");
            entity.Property(e => e.ProductDesc)
                .HasMaxLength(5500)
                .IsUnicode(false);
            entity.Property(e => e.ProductImage)
                .IsUnicode(false)
                .HasColumnName("Product_Image");
            entity.Property(e => e.ProductName)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.ProductPrice).HasColumnType("decimal(9, 3)");
            entity.Property(e => e.ProductSalePrice).HasColumnType("decimal(9, 3)");

            entity.HasOne(d => d.ProductCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategory)
                .HasConstraintName("FK__Product__Product__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
