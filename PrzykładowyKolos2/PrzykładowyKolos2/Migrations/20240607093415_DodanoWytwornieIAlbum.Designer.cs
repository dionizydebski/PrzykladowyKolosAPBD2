﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrzykładowyKolos2.Context;

#nullable disable

namespace PrzykładowyKolos2.Migrations
{
    [DbContext(typeof(ApbdContext))]
    [Migration("20240607093415_DodanoWytwornieIAlbum")]
    partial class DodanoWytwornieIAlbum
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MuzykUtwor", b =>
                {
                    b.Property<int>("MuzycyIdMuzyk")
                        .HasColumnType("int");

                    b.Property<int>("UtworIdUtwor")
                        .HasColumnType("int");

                    b.HasKey("MuzycyIdMuzyk", "UtworIdUtwor");

                    b.HasIndex("UtworIdUtwor");

                    b.ToTable("MuzykUtwor");
                });

            modelBuilder.Entity("PrzykładowyKolos2.Models.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAlbum"));

                    b.Property<DateTime>("DataWydania")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdWytwornia")
                        .HasColumnType("int");

                    b.Property<string>("NazwaAlbumu")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdAlbum");

                    b.HasIndex("IdWytwornia");

                    b.ToTable("Albumy");
                });

            modelBuilder.Entity("PrzykładowyKolos2.Models.Muzyk", b =>
                {
                    b.Property<int>("IdMuzyk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMuzyk"));

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Pseudonim")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMuzyk");

                    b.ToTable("Muzycy");
                });

            modelBuilder.Entity("PrzykładowyKolos2.Models.Utwor", b =>
                {
                    b.Property<int>("IdUtwor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUtwor"));

                    b.Property<float>("CzasTrwania")
                        .HasColumnType("real");

                    b.Property<int?>("IdAlbum")
                        .HasColumnType("int");

                    b.Property<string>("NazwaUtworu")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdUtwor");

                    b.HasIndex("IdAlbum");

                    b.ToTable("Utwory");
                });

            modelBuilder.Entity("PrzykładowyKolos2.Models.Wytwornia", b =>
                {
                    b.Property<int>("IdWytwornia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdWytwornia"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdWytwornia");

                    b.ToTable("Wytwornie");
                });

            modelBuilder.Entity("MuzykUtwor", b =>
                {
                    b.HasOne("PrzykładowyKolos2.Models.Muzyk", null)
                        .WithMany()
                        .HasForeignKey("MuzycyIdMuzyk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrzykładowyKolos2.Models.Utwor", null)
                        .WithMany()
                        .HasForeignKey("UtworIdUtwor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PrzykładowyKolos2.Models.Album", b =>
                {
                    b.HasOne("PrzykładowyKolos2.Models.Wytwornia", "Wytwornia")
                        .WithMany("Albumy")
                        .HasForeignKey("IdWytwornia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wytwornia");
                });

            modelBuilder.Entity("PrzykładowyKolos2.Models.Utwor", b =>
                {
                    b.HasOne("PrzykładowyKolos2.Models.Album", "Albumy")
                        .WithMany("Utwory")
                        .HasForeignKey("IdAlbum");

                    b.Navigation("Albumy");
                });

            modelBuilder.Entity("PrzykładowyKolos2.Models.Album", b =>
                {
                    b.Navigation("Utwory");
                });

            modelBuilder.Entity("PrzykładowyKolos2.Models.Wytwornia", b =>
                {
                    b.Navigation("Albumy");
                });
#pragma warning restore 612, 618
        }
    }
}
