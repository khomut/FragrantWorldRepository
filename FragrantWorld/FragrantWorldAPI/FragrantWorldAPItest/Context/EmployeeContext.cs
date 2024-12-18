﻿using System;
using System.Collections.Generic;
using FragrantWorldAPItest.Models;
using Microsoft.EntityFrameworkCore;

namespace FragrantWorldAPItest.Context;

public partial class EmployeeContext : DbContext
{
    public EmployeeContext()
    {
    }

    public EmployeeContext(DbContextOptions<EmployeeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<PickupPoint> PickupPoints { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ISPP2114\\SQLEXPRESS;Initial Catalog=FragmentWorld;User Id=log;Password=123;Trusted_Connection=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__ExamOrde__C3905BAFB5D46591");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderDeliveryDate).HasColumnType("datetime");

            entity.HasOne(d => d.OrderPickupPointNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderPickupPoint)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExamOrder_ExamPickupPoint");

            entity.HasOne(d => d.OrderUser).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderUserId)
                .HasConstraintName("FK_ExamOrder_ExamUser");
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductArticleNumber }).HasName("PK__ExamOrde__817A26628805FBC8");

            entity.ToTable("OrderProduct");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductArticleNumber).HasMaxLength(100);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExamOrder__Order__4AB81AF0");

            entity.HasOne(d => d.ProductArticleNumberNavigation).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.ProductArticleNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExamOrder__Produ__4BAC3F29");
        });

        modelBuilder.Entity<PickupPoint>(entity =>
        {
            entity.HasKey(e => e.PickupPointId).HasName("PK_ExamPickupPoint");

            entity.ToTable("PickupPoint");

            entity.Property(e => e.PickupPointAddress).HasMaxLength(200);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductArticleNumber).HasName("PK__ExamProd__2EA7DCD574DE71DE");

            entity.ToTable("Product");

            entity.Property(e => e.ProductArticleNumber).HasMaxLength(100);
            entity.Property(e => e.ProductCost).HasColumnType("decimal(19, 2)");
            entity.Property(e => e.ProductPhoto).HasColumnType("image");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3AC4CA107A");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__ExamUser__1788CCACFA3D9E98");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserName).HasMaxLength(100);
            entity.Property(e => e.UserPatronymic).HasMaxLength(100);
            entity.Property(e => e.UserSurname).HasMaxLength(100);

            entity.HasOne(d => d.UserRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExamUser__UserRo__367C1819");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
