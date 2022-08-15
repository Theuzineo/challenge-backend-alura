﻿// <auto-generated />
using System;
using BackEnd_Challenge_Alura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEnd_Challenge_Alura.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220811173122_teste")]
    partial class teste
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BackEnd_Challenge_Alura.Models.Despesas", b =>
                {
                    b.Property<int>("IdDespesa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDespesa"), 1L, 1);

                    b.Property<int>("CategoriaDespesa")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDespesa")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescricaoDespesa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("ValorDespesa")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdDespesa");

                    b.ToTable("DespesasDb");
                });

            modelBuilder.Entity("BackEnd_Challenge_Alura.Models.Receitas", b =>
                {
                    b.Property<int>("IdReceita")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReceita"), 1L, 1);

                    b.Property<DateTime>("DataReceita")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescricaoReceita")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("ValorReceita")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdReceita");

                    b.ToTable("ReceitasDb");
                });
#pragma warning restore 612, 618
        }
    }
}
