using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsoleReverseDb.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kuliah> Kuliahs { get; set; } = null!;
        public virtual DbSet<Lecturer> Lecturers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=SampleAdoDb;Integrated Security=SSPI");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kuliah>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Kuliah");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.LecturerId)
                    .HasMaxLength(10)
                    .HasColumnName("lecturerId")
                    .IsFixedLength();

                entity.Property(e => e.Matkul).HasMaxLength(50);
            });

            modelBuilder.Entity<Lecturer>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Alamat).HasMaxLength(50);

                entity.Property(e => e.Nama).HasMaxLength(50);

                entity.Property(e => e.Nik)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Telp).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
