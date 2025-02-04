﻿// <auto-generated />
using System;
using GerenciamentoDeChamados.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GerenciamentoDeChamados.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GerenciamentoDeChamados.Domain.Entities.Anexo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CaminhoArquivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ChamadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataUpload")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeArquivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChamadoId");

                    b.ToTable("Anexos");
                });

            modelBuilder.Entity("GerenciamentoDeChamados.Domain.Entities.Chamado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prioridade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Chamados");
                });

            modelBuilder.Entity("GerenciamentoDeChamados.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("GerenciamentoDeChamados.Domain.Entities.Anexo", b =>
                {
                    b.HasOne("GerenciamentoDeChamados.Domain.Entities.Chamado", "Chamado")
                        .WithMany("Anexos")
                        .HasForeignKey("ChamadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chamado");
                });

            modelBuilder.Entity("GerenciamentoDeChamados.Domain.Entities.Chamado", b =>
                {
                    b.HasOne("GerenciamentoDeChamados.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Chamados")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("GerenciamentoDeChamados.Domain.Entities.Chamado", b =>
                {
                    b.Navigation("Anexos");
                });

            modelBuilder.Entity("GerenciamentoDeChamados.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Chamados");
                });
#pragma warning restore 612, 618
        }
    }
}
