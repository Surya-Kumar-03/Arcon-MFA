﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using testAPI.Helpers;

#nullable disable

namespace webapi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230717105530_InitialDBCreate")]
    partial class InitialDBCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("testAPI.Models.UserDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("browser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("latitude")
                        .HasColumnType("float");

                    b.Property<double?>("longitude")
                        .HasColumnType("float");

                    b.Property<string>("os")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
