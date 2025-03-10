﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POSniLeinard.Model;

#nullable disable

namespace POSniLeinard.Migrations
{
    [DbContext(typeof(POSDbContext))]
    [Migration("20240504114615_add")]
    partial class add
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("POSniLeinard.Model.Tbl_Customer", b =>
                {
                    b.Property<long>("Customer_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Customer_Id"));

                    b.Property<string>("First_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone_number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Customer_Id");

                    b.ToTable("Tbl_Costumers");
                });

            modelBuilder.Entity("POSniLeinard.Model.Tbl_Product", b =>
                {
                    b.Property<long>("Product_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Product_Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Qty")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Product_Id");

                    b.ToTable("Tbl_Products");
                });

            modelBuilder.Entity("POSniLeinard.Model.Tbl_SaleDetails", b =>
                {
                    b.Property<long>("Sales_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Sales_Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedStamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Qty")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("Tbl_ProductsProduct_Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("Tbl_SalesHeaderSales_Id")
                        .HasColumnType("bigint");

                    b.HasKey("Sales_Id");

                    b.HasIndex("Tbl_ProductsProduct_Id");

                    b.HasIndex("Tbl_SalesHeaderSales_Id");

                    b.ToTable("Tbl_SaleDetails");
                });

            modelBuilder.Entity("POSniLeinard.Model.Tbl_SalesHeader", b =>
                {
                    b.Property<long>("Sales_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Sales_Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Customer_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Product_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Tbl_CustomersCustomer_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Transaction_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Sales_Id");

                    b.HasIndex("Tbl_CustomersCustomer_Id");

                    b.ToTable("Tbl_SalesHeaders");
                });

            modelBuilder.Entity("POSniLeinard.Model.Tbl_User", b =>
                {
                    b.Property<long>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("User_Id"));

                    b.Property<string>("First_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_Id");

                    b.ToTable("Tbl_Users");
                });

            modelBuilder.Entity("POSniLeinard.Model.Tbl_SaleDetails", b =>
                {
                    b.HasOne("POSniLeinard.Model.Tbl_Product", "Tbl_Products")
                        .WithMany()
                        .HasForeignKey("Tbl_ProductsProduct_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POSniLeinard.Model.Tbl_SalesHeader", null)
                        .WithMany("Tbl_SaleDetails")
                        .HasForeignKey("Tbl_SalesHeaderSales_Id");

                    b.Navigation("Tbl_Products");
                });

            modelBuilder.Entity("POSniLeinard.Model.Tbl_SalesHeader", b =>
                {
                    b.HasOne("POSniLeinard.Model.Tbl_Customer", "Tbl_Customers")
                        .WithMany()
                        .HasForeignKey("Tbl_CustomersCustomer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tbl_Customers");
                });

            modelBuilder.Entity("POSniLeinard.Model.Tbl_SalesHeader", b =>
                {
                    b.Navigation("Tbl_SaleDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
