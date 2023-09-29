﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WantedRobots.Models;

#nullable disable

namespace WantedRobots.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230926130745_nouveauNomDeTable")]
    partial class nouveauNomDeTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WantedRobots.Models.Agent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Commentaire")
                        .HasColumnType("longtext");

                    b.Property<string>("Continent")
                        .HasColumnType("longtext");

                    b.Property<double>("Identification")
                        .HasColumnType("double");

                    b.Property<string>("NomAgent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("WantedRobots.Models.DeletedRobot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnType("longtext");

                    b.Property<string>("Pays")
                        .HasColumnType("longtext");

                    b.Property<double>("Poids")
                        .HasColumnType("double");

                    b.Property<double>("Taille")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("DeletedRobots");
                });

            modelBuilder.Entity("WantedRobots.Models.Robot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Pays")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Poids")
                        .HasColumnType("double");

                    b.Property<double>("Taille")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Robots", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
