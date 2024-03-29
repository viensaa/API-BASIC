﻿// <auto-generated />
using ConsoleReverseDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsoleReverseDb.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220712091218_many_to_many_tabelSamuraiToBattle")]
    partial class many_to_many_tabelSamuraiToBattle
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ConsoleReverseDb.Models.Kuliah", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("LecturerId")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("lecturerId")
                        .IsFixedLength();

                    b.Property<string>("Matkul")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.ToTable("Kuliah", (string)null);
                });

            modelBuilder.Entity("ConsoleReverseDb.Models.Lecturer", b =>
                {
                    b.Property<string>("Alamat")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nik")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("Telp")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.ToTable("Lecturers");
                });
#pragma warning restore 612, 618
        }
    }
}
