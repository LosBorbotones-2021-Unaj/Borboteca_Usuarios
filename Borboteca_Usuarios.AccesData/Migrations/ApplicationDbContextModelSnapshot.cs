﻿// <auto-generated />
using System;
using Borboteca_Usuarios.AccesData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Borboteca_Usuarios.AccesData.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Borboteca_Usuarios.Domain.Entities.Favoritos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("Libroid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Usuariosid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Usuariosid");

                    b.ToTable("Favoritos");
                });

            modelBuilder.Entity("Borboteca_Usuarios.Domain.Entities.Roll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Roll");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "user"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "admin"
                        });
                });

            modelBuilder.Entity("Borboteca_Usuarios.Domain.Entities.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Rollid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Rollid");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Borboteca_Usuarios.Domain.Entities.Favoritos", b =>
                {
                    b.HasOne("Borboteca_Usuarios.Domain.Entities.Usuarios", "Usuarios")
                        .WithMany("Favoritos")
                        .HasForeignKey("Usuariosid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Borboteca_Usuarios.Domain.Entities.Usuarios", b =>
                {
                    b.HasOne("Borboteca_Usuarios.Domain.Entities.Roll", "Roll")
                        .WithMany()
                        .HasForeignKey("Rollid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roll");
                });

            modelBuilder.Entity("Borboteca_Usuarios.Domain.Entities.Usuarios", b =>
                {
                    b.Navigation("Favoritos");
                });
#pragma warning restore 612, 618
        }
    }
}
