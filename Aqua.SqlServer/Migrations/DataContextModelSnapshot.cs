﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using com.marcelbenders.Aqua.SqlServer;

#nullable disable

namespace com.marcelbenders.Aqua.SqlServer.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("com.marcelbenders.Aqua.Domain.Sql.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

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
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

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
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AquariumId");

                    b.HasIndex("UserId");

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Wissenschaftlich")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AquariumId");

                    b.HasIndex("UserId");

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Wissenschaftlich")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AquariumId");

                    b.HasIndex("UserId");

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Wert")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AquariumId");

                    b.HasIndex("UserId");

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
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AquariumId");

                    b.HasIndex("UserId");

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Wachstum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wissenschaftlich")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AquariumId");

                    b.HasIndex("UserId");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("com.marcelbenders.Aqua.Domain.Sql.Aquarium", b =>
                {
                    b.HasOne("com.marcelbenders.Aqua.Domain.Sql.AppUser", "AppUser")
                        .WithMany("Aquarien")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("com.marcelbenders.Aqua.Domain.Sql.Duengung", b =>
                {
                    b.HasOne("com.marcelbenders.Aqua.Domain.Sql.Aquarium", "Aquarium")
                        .WithMany()
                        .HasForeignKey("AquariumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("com.marcelbenders.Aqua.Domain.Sql.AppUser", "AppUser")
                        .WithMany("Duengungen")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Aquarium");
                });

            modelBuilder.Entity("com.marcelbenders.Aqua.Domain.Sql.Fisch", b =>
                {
                    b.HasOne("com.marcelbenders.Aqua.Domain.Sql.Aquarium", "Aquarium")
                        .WithMany()
                        .HasForeignKey("AquariumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("com.marcelbenders.Aqua.Domain.Sql.AppUser", "AppUser")
                        .WithMany("Fische")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Aquarium");
                });

            modelBuilder.Entity("com.marcelbenders.Aqua.Domain.Sql.Koralle", b =>
                {
                    b.HasOne("com.marcelbenders.Aqua.Domain.Sql.Aquarium", "Aquarium")
                        .WithMany()
                        .HasForeignKey("AquariumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("com.marcelbenders.Aqua.Domain.Sql.AppUser", "AppUser")
                        .WithMany("Korallen")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Aquarium");
                });

            modelBuilder.Entity("com.marcelbenders.Aqua.Domain.Sql.Messung", b =>
                {
                    b.HasOne("com.marcelbenders.Aqua.Domain.Sql.Aquarium", "Aquarium")
                        .WithMany()
                        .HasForeignKey("AquariumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("com.marcelbenders.Aqua.Domain.Sql.AppUser", "AppUser")
                        .WithMany("Messungen")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Aquarium");
                });

            modelBuilder.Entity("com.marcelbenders.Aqua.Domain.Sql.Notiz", b =>
                {
                    b.HasOne("com.marcelbenders.Aqua.Domain.Sql.Aquarium", "Aquarium")
                        .WithMany()
                        .HasForeignKey("AquariumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("com.marcelbenders.Aqua.Domain.Sql.AppUser", "AppUser")
                        .WithMany("Notizen")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Aquarium");
                });

            modelBuilder.Entity("com.marcelbenders.Aqua.Domain.Sql.Pflanze", b =>
                {
                    b.HasOne("com.marcelbenders.Aqua.Domain.Sql.Aquarium", "Aquarium")
                        .WithMany()
                        .HasForeignKey("AquariumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("com.marcelbenders.Aqua.Domain.Sql.AppUser", "AppUser")
                        .WithMany("Pflanzen")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Aquarium");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("com.marcelbenders.Aqua.Domain.Sql.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("com.marcelbenders.Aqua.Domain.Sql.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("com.marcelbenders.Aqua.Domain.Sql.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("com.marcelbenders.Aqua.Domain.Sql.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("com.marcelbenders.Aqua.Domain.Sql.AppUser", b =>
                {
                    b.Navigation("Aquarien");

                    b.Navigation("Duengungen");

                    b.Navigation("Fische");

                    b.Navigation("Korallen");

                    b.Navigation("Messungen");

                    b.Navigation("Notizen");

                    b.Navigation("Pflanzen");
                });
#pragma warning restore 612, 618
        }
    }
}
