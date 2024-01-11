using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Squadmakers.DomainObjects.Entities
{
    public partial class SquadmakersdbContext : DbContext
    {
        public SquadmakersdbContext()
        {
        }

        public SquadmakersdbContext(DbContextOptions<SquadmakersdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chistes> Chistes { get; set; }
        public virtual DbSet<ChistesTematicas> ChistesTematicas { get; set; }
        public virtual DbSet<Tematicas> Tematicas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-4225H89;Database=Squadmakersdb; Integrated Security=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chistes>(entity =>
            {
                entity.ToTable("chistes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasColumnName("activo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Autor).HasColumnName("autor");

                entity.Property(e => e.Cuerpo)
                    .IsRequired()
                    .HasColumnName("cuerpo")
                    .HasColumnType("text");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fecha_creacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.AutorNavigation)
                    .WithMany(p => p.Chistes)
                    .HasForeignKey(d => d.Autor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__chistes__autor__44FF419A");
            });

            modelBuilder.Entity<ChistesTematicas>(entity =>
            {
                entity.HasKey(e => new { e.ChisteId, e.TematicaId })
                    .HasName("PK__chistes___B68268455DC50C26");

                entity.ToTable("chistes_tematicas");

                entity.Property(e => e.ChisteId).HasColumnName("chiste_id");

                entity.Property(e => e.TematicaId).HasColumnName("tematica_id");

                entity.HasOne(d => d.Chiste)
                    .WithMany(p => p.ChistesTematicas)
                    .HasForeignKey(d => d.ChisteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__chistes_t__chist__4BAC3F29");

                entity.HasOne(d => d.Tematica)
                    .WithMany(p => p.ChistesTematicas)
                    .HasForeignKey(d => d.TematicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__chistes_t__temat__4CA06362");
            });

            modelBuilder.Entity<Tematicas>(entity =>
            {
                entity.ToTable("tematicas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasColumnName("contrasena")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
