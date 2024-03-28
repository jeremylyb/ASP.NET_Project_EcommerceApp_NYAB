using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NotYourAverageBicepShoppingApp.ProductRestApi.Models;

/// <summary>
/// Represents the database context for managing product-related entities.
/// </summary>
public partial class ProductsNyabContext : DbContext
{
    // Remove OnConfiguring() and no Args constructor - Refer to notes for explanation

    //public ProductsNyabContext()
    //{
    //}


    /// <summary>
    /// Initializes a new instance of the <see cref="ProductsNyabContext"/> class.
    /// </summary>
    /// <param name="options">The options to be used by the context.</param>
    public ProductsNyabContext(DbContextOptions<ProductsNyabContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the DbSet of products.
    /// </summary>
    public virtual DbSet<Product> Products { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-DQUSH87; Initial Catalog=ProductsNYAB; Integrated Security=sspi; TrustServerCertificate=True;");


    /// <summary>
    /// Configures the behavior of the entity types in the model.
    /// </summary>
    /// <param name="modelBuilder">The model builder being used to construct the model for this context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__9834FBBA2F93F78A");

            entity.Property(e => e.ProductId).HasColumnName("Product_Id");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .HasColumnName("Product_Name");
            entity.Property(e => e.ProductPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Product_Price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    /// <summary>
    /// Provides additional configuration for the model builder.
    /// </summary>
    /// <param name="modelBuilder">The model builder being used to construct the model for this context.</param>
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
