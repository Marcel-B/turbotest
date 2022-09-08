﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using com.marcelbenders.Aqua.SqlServer;

#nullable disable

namespace com.marcelbenders.Aqua.SqlServer.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220802161031_RemoveUser")]
    partial class RemoveUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("com.marcelbenders.Aqua.Domain.Sql.Aquarium", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Datum")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Liter")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Aquarien");
                });

            modelBuilder.Entity("com.marcelbenders.Aqua.Domain.Sql.Duengung", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AquariumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Datum")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Duenger")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Menge")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AquariumId");

                    b.ToTable("Duengungen");
                });

            modelBuilder.Entity("com.marcelbenders.Aqua.Domain.Sql.Fisch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Anzahl")
                        .HasColumnType("int");

                    b.Property<Guid>("AquariumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Datum")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Geschlecht")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Herkunft")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ph")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Schwimmzone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Temperatur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wissenschaftlich")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AquariumId");

                    b.ToTable("Fische");
                });

            modelBuilder.Entity("com.marcelbenders.Aqua.Domain.Sql.Koralle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AquariumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Calcium")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Datum")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Herkunft")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Magnesium")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nitrat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phosphat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salinitaet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Schwierigkeitsgrad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stroemung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Temperatur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wissenschaftlich")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AquariumId");

                    b.ToTable("Korallen");
                });

            modelBuilder.Entity("com.marcelbenders.Aqua.Domain.Sql.Messung", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AquariumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Datum")
                        .HasColumnType("datetimeoffset");

                    b.Property<double>("Menge")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wert")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AquariumId");

                    b.ToTable("Messungen");
                });

            modelBuilder.Entity("com.marcelbenders.Aqua.Domain.Sql.Notiz", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AquariumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Datum")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AquariumId");

                    b.ToTable("Notizen");
                });

            modelBuilder.Entity("com.marcelbenders.Aqua.Domain.Sql.Pflanze", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AquariumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bereich")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Datum")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("Emers")
                        .HasColumnType("bit");

                    b.Property<string>("Gh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Herkunft")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ph")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Schwierigkeitsgrad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Temperatur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wachstum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wissenschaftlich")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AquariumId");

                    b.ToTable("Pflanzen");
                });

            modelBuilder.Entity("com.marcelbenders.Aqua.Domain.Sql.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("com.marcelbenders.Aqua.Domain.Sql.Duengung", b =>
                {
                    b.HasOne("com.marcelbenders.Aqua.Domain.Sql.Aquarium", "Aquarium")
                        .WithMany()
                        .HasForeignKey("AquariumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aquarium");
                });

            modelBuilder.Entity("com.marcelbenders.Aqua.Domain.Sql.Fisch", b =>
                {
                    b.HasOne("com.marcelbenders.Aqua.Domain.Sql.Aquarium", "Aquarium")
                        .WithMany()
                        .HasForeignKey("AquariumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aquarium");
                });

            modelBuilder.Entity("com.marcelbenders.Aqua.Domain.Sql.Koralle", b =>
                {
                    b.HasOne("com.marcelbenders.Aqua.Domain.Sql.Aquarium", "Aquarium")
                        .WithMany()
                        .HasForeignKey("AquariumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aquarium");
                });

            modelBuilder.Entity("com.marcelbenders.Aqua.Domain.Sql.Messung", b =>
                {
                    b.HasOne("com.marcelbenders.Aqua.Domain.Sql.Aquarium", "Aquarium")
                        .WithMany()
                        .HasForeignKey("AquariumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aquarium");
                });

            modelBuilder.Entity("com.marcelbenders.Aqua.Domain.Sql.Notiz", b =>
                {
                    b.HasOne("com.marcelbenders.Aqua.Domain.Sql.Aquarium", "Aquarium")
                        .WithMany()
                        .HasForeignKey("AquariumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aquarium");
                });

            modelBuilder.Entity("com.marcelbenders.Aqua.Domain.Sql.Pflanze", b =>
                {
                    b.HasOne("com.marcelbenders.Aqua.Domain.Sql.Aquarium", "Aquarium")
                        .WithMany()
                        .HasForeignKey("AquariumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aquarium");
                });
#pragma warning restore 612, 618
        }
    }
}