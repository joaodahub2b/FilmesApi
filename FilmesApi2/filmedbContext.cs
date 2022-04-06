using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FilmesApi2
{
    public partial class filmedbContext : DbContext
    {
        public filmedbContext()
        {
        }

        public filmedbContext(DbContextOptions<filmedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cinema> Cinemas { get; set; } = null!;
        public virtual DbSet<Endereco> Enderecos { get; set; } = null!;
        public virtual DbSet<Filme> Filmes { get; set; } = null!;
        public virtual DbSet<Sessao> Sessaos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=filmedb;uid=root;pwd=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.ToTable("cinema");

                entity.HasIndex(e => e.EnderecoId, "EnderecoId_idx");

                entity.Property(e => e.Nome).HasMaxLength(45);

                entity.HasOne(d => d.Endereco)
                    .WithMany(p => p.Cinemas)
                    .HasForeignKey(d => d.EnderecoId)
                    .HasConstraintName("EnderecoId");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("endereco");

                entity.Property(e => e.Bairro).HasMaxLength(45);

                entity.Property(e => e.Logradouro).HasMaxLength(45);
            });

            modelBuilder.Entity<Filme>(entity =>
            {
                entity.ToTable("filme");

                entity.Property(e => e.Diretor).HasMaxLength(45);

                entity.Property(e => e.Genero).HasMaxLength(45);

                entity.Property(e => e.Titulo).HasMaxLength(45);
            });

            modelBuilder.Entity<Sessao>(entity =>
            {
                entity.ToTable("sessao");

                entity.HasIndex(e => e.CinemaId, "cinemaId_idx");

                entity.HasIndex(e => e.FilmeId, "filmeId_idx");

                entity.Property(e => e.CinemaId).HasColumnName("cinemaId");

                entity.Property(e => e.FilmeId).HasColumnName("filmeId");

                entity.Property(e => e.HorarioEncerramento)
                    .HasColumnType("datetime")
                    .HasColumnName("horarioEncerramento");

                entity.HasOne(d => d.Cinema)
                    .WithMany(p => p.Sessaos)
                    .HasForeignKey(d => d.CinemaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cinemaId");

                entity.HasOne(d => d.Filme)
                    .WithMany(p => p.Sessaos)
                    .HasForeignKey(d => d.FilmeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("filmeId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
