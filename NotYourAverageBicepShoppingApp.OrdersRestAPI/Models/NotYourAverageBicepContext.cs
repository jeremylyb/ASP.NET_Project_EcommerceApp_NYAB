using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NotYourAverageBicepShoppingApp.OrdersRestAPI.Models;

public partial class NotYourAverageBicepContext : DbContext
{
    //public NotYourAverageBicepContext()
    //{
    //}

    public NotYourAverageBicepContext(DbContextOptions<NotYourAverageBicepContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-DQUSH87; Initial Catalog=NotYourAverageBicep; Integrated Security=sspi; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__F1E4607BAEF44DB6");

            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.CartId).HasColumnName("Cart_Id");
            entity.Property(e => e.CustomerAddress).HasColumnName("Customer_Address");
            entity.Property(e => e.CustomerCreditCardNumber).HasColumnName("Customer_CreditCardNumber");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .HasColumnName("Customer_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
