using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NotYourAverageBicepShoppingApp.CartsRestAPI.Models;

public partial class NotYourAverageBicepContext : DbContext
{
    //public NotYourAverageBicepContext()
    //{
    //}

    public NotYourAverageBicepContext(DbContextOptions<NotYourAverageBicepContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-DQUSH87; Initial Catalog=NotYourAverageBicep; Integrated Security=sspi; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Carts__D6AB4759CFCCD4C7");

            entity.Property(e => e.CartId).HasColumnName("Cart_Id");
            entity.Property(e => e.CartPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Cart_Price");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.CartItemId).HasName("PK__Cart_Ite__3C0F265CD2FD28D3");

            entity.ToTable("Cart_Items");

            entity.Property(e => e.CartItemId).HasColumnName("Cart_Item_Id");
            entity.Property(e => e.FkCartId).HasColumnName("Fk_Cart_Id");
            entity.Property(e => e.ProductId).HasColumnName("Product_Id");

            entity.HasOne(d => d.FkCart).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.FkCartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart_Item__Fk_Ca__3B75D760");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__F1E4607B91C1DEF3");

            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.CartId).HasColumnName("Cart_Id");
            entity.Property(e => e.CustomerAddress).HasColumnName("Customer_Address");
            entity.Property(e => e.CustomerCreditCardNumber).HasColumnName("Customer_CreditCardNumber");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .HasColumnName("Customer_Name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__9834FBBA74FD228D");

            entity.Property(e => e.ProductId).HasColumnName("Product_Id");
            entity.Property(e => e.ProductBenefits).HasColumnName("Product_Benefits");
            entity.Property(e => e.ProductImage).HasColumnName("Product_Image");
            entity.Property(e => e.ProductName)
                .HasMaxLength(300)
                .HasColumnName("Product_Name");
            entity.Property(e => e.ProductOverview).HasColumnName("Product_Overview");
            entity.Property(e => e.ProductPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Product_Price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
