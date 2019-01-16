﻿// <auto-generated />
using System;
using EFSortingPagingFIltering.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFSortingPagingFIltering.Migrations
{
    [DbContext(typeof(OpleidingContext))]
    [Migration("20190115110519_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFSortingPagingFIltering.Models.Cursus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam");

                    b.HasKey("Id");

                    b.ToTable("Cursus");
                });

            modelBuilder.Entity("EFSortingPagingFIltering.Models.Inschrijving", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CursusId");

                    b.Property<int?>("Punten");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("CursusId");

                    b.HasIndex("StudentId");

                    b.ToTable("Inschrijving");
                });

            modelBuilder.Entity("EFSortingPagingFIltering.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Achternaam");

                    b.Property<DateTime>("InschrijvingsDatum");

                    b.Property<string>("Voornaam");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("EFSortingPagingFIltering.Models.Inschrijving", b =>
                {
                    b.HasOne("EFSortingPagingFIltering.Models.Cursus", "Cursus")
                        .WithMany("Inschrijving")
                        .HasForeignKey("CursusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFSortingPagingFIltering.Models.Student", "Student")
                        .WithMany("Inschrijving")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
