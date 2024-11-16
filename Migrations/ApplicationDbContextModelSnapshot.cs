﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vazar.Data;

#nullable disable

namespace Vazar.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Vazar.Data.model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            //products
            modelBuilder.Entity("Vazar.Data.model.Product", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("varchar(255)"); // Naziv proizvoda (ograničenje duljine)

                b.Property<string>("Description")
                    .HasColumnType("text"); // Opis proizvoda

                b.Property<decimal>("StartingPrice")
                    .IsRequired()
                    .HasColumnType("decimal(10,2)"); // Početna cijena

                b.Property<string>("ImageUrl")
                    .HasColumnType("varchar(2083)"); // URL slike

                b.Property<DateTime>("AuctionEndDate")
                    .IsRequired()
                    .HasColumnType("datetime"); // Datum i vrijeme završetka aukcije

                b.HasKey("Id");

                b.ToTable("Products"); // Naziv tablice
            });

#pragma warning restore 612, 618
        }
    }
}
