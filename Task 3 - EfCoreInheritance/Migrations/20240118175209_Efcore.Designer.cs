﻿// <auto-generated />
using System;
using EfCoreInheritance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfCoreInheritance.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20240118175209_Efcore")]
    partial class Efcore
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EfCoreInheritance.EmployeeModel", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ManagerEmployeeId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("ManagerEmployeeId");

                    b.ToTable("Employees");

                    b.HasDiscriminator<string>("Discriminator").HasValue("EmployeeModel");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EfCoreInheritance.Manager", b =>
                {
                    b.HasBaseType("EfCoreInheritance.EmployeeModel");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Manager");
                });

            modelBuilder.Entity("EfCoreInheritance.RegularEmployee", b =>
                {
                    b.HasBaseType("EfCoreInheritance.EmployeeModel");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("RegularEmployee");
                });

            modelBuilder.Entity("EfCoreInheritance.EmployeeModel", b =>
                {
                    b.HasOne("EfCoreInheritance.EmployeeModel", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerEmployeeId");

                    b.Navigation("Manager");
                });
#pragma warning restore 612, 618
        }
    }
}
