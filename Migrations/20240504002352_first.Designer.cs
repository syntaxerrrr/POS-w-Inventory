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
    [Migration("20240504002352_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("POSniLeinard.Model.Tbl_Costumer", b =>
                {
                    b.Property<long>("Costumer_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Costumer_Id"));

                    b.Property<string>("First_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone_number")
                        .HasColumnType("int");

                    b.HasKey("Costumer_Id");

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

            modelBuilder.Entity("POSniLeinard.Model.Tbl_Sale", b =>
                {
                    b.Property<long>("Sales_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Sales_Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedStamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Sales_Id");

                    b.ToTable("Tbl_Sales");
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
#pragma warning restore 612, 618
        }
    }
}
