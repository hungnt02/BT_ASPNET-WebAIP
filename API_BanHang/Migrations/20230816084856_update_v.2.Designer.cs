﻿// <auto-generated />
using System;
using API_BanHang.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_BanHang.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230816084856_update_v.2")]
    partial class update_v2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_BanHang.Entity.Bill", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillId"));

                    b.Property<string>("BillName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("ToltalPrice")
                        .HasColumnType("float");

                    b.Property<string>("TradeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BillId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("API_BanHang.Entity.BillDetail", b =>
                {
                    b.Property<int>("BillDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillDetailId"));

                    b.Property<int>("BillId")
                        .HasColumnType("int");

                    b.Property<string>("DVT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("BillDetailId");

                    b.HasIndex("BillId");

                    b.HasIndex("ProductId");

                    b.ToTable("BillDetails");
                });

            modelBuilder.Entity("API_BanHang.Entity.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<DateTime>("Born")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sdt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("API_BanHang.Entity.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("float");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("API_BanHang.Entity.ProductType", b =>
                {
                    b.Property<int>("ProductTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductTypeId"));

                    b.Property<string>("ProductTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductTypeId");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("API_BanHang.Entity.Bill", b =>
                {
                    b.HasOne("API_BanHang.Entity.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.Navigation("customer");
                });

            modelBuilder.Entity("API_BanHang.Entity.BillDetail", b =>
                {
                    b.HasOne("API_BanHang.Entity.Bill", "bill")
                        .WithMany("billDetails")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_BanHang.Entity.Product", "product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("bill");

                    b.Navigation("product");
                });

            modelBuilder.Entity("API_BanHang.Entity.Product", b =>
                {
                    b.HasOne("API_BanHang.Entity.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("API_BanHang.Entity.Bill", b =>
                {
                    b.Navigation("billDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
