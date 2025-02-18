﻿// <auto-generated />
using IntegradorEDI2024.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IntegradorEDI2024.Datos.Migrations
{
    [DbContext(typeof(MiDbContext))]
    partial class MiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IntegradorEDI2024.Entidades.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandId"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BrandId");

                    b.HasIndex("BrandName")
                        .IsUnique();

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            BrandId = 1,
                            BrandName = "Topper"
                        },
                        new
                        {
                            BrandId = 2,
                            BrandName = "Etnies"
                        },
                        new
                        {
                            BrandId = 3,
                            BrandName = "Ocn"
                        },
                        new
                        {
                            BrandId = 4,
                            BrandName = "Vicus"
                        },
                        new
                        {
                            BrandId = 5,
                            BrandName = "Nike"
                        });
                });

            modelBuilder.Entity("IntegradorEDI2024.Entidades.Color", b =>
                {
                    b.Property<int>("ColorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ColorId"));

                    b.Property<string>("ColorName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ColorId");

                    b.HasIndex("ColorName")
                        .IsUnique();

                    b.ToTable("Colors");

                    b.HasData(
                        new
                        {
                            ColorId = 1,
                            ColorName = "red"
                        },
                        new
                        {
                            ColorId = 2,
                            ColorName = "black"
                        },
                        new
                        {
                            ColorId = 3,
                            ColorName = "white"
                        });
                });

            modelBuilder.Entity("IntegradorEDI2024.Entidades.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("GenreId");

                    b.HasIndex("GenreName")
                        .IsUnique();

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            GenreName = "Male"
                        },
                        new
                        {
                            GenreId = 2,
                            GenreName = "Female"
                        });
                });

            modelBuilder.Entity("IntegradorEDI2024.Entidades.Shoe", b =>
                {
                    b.Property<int>("ShoeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShoeId"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SportId")
                        .HasColumnType("int");

                    b.HasKey("ShoeId");

                    b.HasIndex("BrandId");

                    b.HasIndex("ColorId");

                    b.HasIndex("GenreId");

                    b.HasIndex("SportId");

                    b.ToTable("Shoes");

                    b.HasData(
                        new
                        {
                            ShoeId = 1,
                            BrandId = 1,
                            ColorId = 1,
                            Description = "Zapatillas running de tela ultra lijero",
                            GenreId = 1,
                            Model = "Capitan",
                            Price = 22999.99m,
                            SportId = 1
                        },
                        new
                        {
                            ShoeId = 2,
                            BrandId = 2,
                            ColorId = 2,
                            Description = "Botas de trekking suela reforzada",
                            GenreId = 2,
                            Model = "Mamooth",
                            Price = 48999.99m,
                            SportId = 2
                        },
                        new
                        {
                            ShoeId = 3,
                            BrandId = 5,
                            ColorId = 1,
                            Description = "Botines de football ultra liviano",
                            GenreId = 1,
                            Model = "Mercurial Vapor",
                            Price = 130789.65m,
                            SportId = 3
                        });
                });

            modelBuilder.Entity("IntegradorEDI2024.Entidades.Sport", b =>
                {
                    b.Property<int>("SportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SportId"));

                    b.Property<string>("SportName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("SportId");

                    b.HasIndex("SportName")
                        .IsUnique();

                    b.ToTable("Sports");

                    b.HasData(
                        new
                        {
                            SportId = 1,
                            SportName = "Running"
                        },
                        new
                        {
                            SportId = 2,
                            SportName = "Trekking"
                        },
                        new
                        {
                            SportId = 3,
                            SportName = "Football"
                        });
                });

            modelBuilder.Entity("IntegradorEDI2024.Entidades.Shoe", b =>
                {
                    b.HasOne("IntegradorEDI2024.Entidades.Brand", "Brand")
                        .WithMany("Shoes")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IntegradorEDI2024.Entidades.Color", "Color")
                        .WithMany("Shoes")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IntegradorEDI2024.Entidades.Genre", "Genre")
                        .WithMany("Shoes")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IntegradorEDI2024.Entidades.Sport", "Sport")
                        .WithMany("Shoes")
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Color");

                    b.Navigation("Genre");

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("IntegradorEDI2024.Entidades.Brand", b =>
                {
                    b.Navigation("Shoes");
                });

            modelBuilder.Entity("IntegradorEDI2024.Entidades.Color", b =>
                {
                    b.Navigation("Shoes");
                });

            modelBuilder.Entity("IntegradorEDI2024.Entidades.Genre", b =>
                {
                    b.Navigation("Shoes");
                });

            modelBuilder.Entity("IntegradorEDI2024.Entidades.Sport", b =>
                {
                    b.Navigation("Shoes");
                });
#pragma warning restore 612, 618
        }
    }
}
