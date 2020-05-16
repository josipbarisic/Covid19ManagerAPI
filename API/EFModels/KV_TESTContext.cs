using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.EFModels
{
    public partial class KV_TESTContext : DbContext
    {
        public KV_TESTContext()
        {
        }

        public KV_TESTContext(DbContextOptions<KV_TESTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<_02Doktori> _02Doktori { get; set; }
        public virtual DbSet<_02LokacijaPacijenta> _02LokacijaPacijenta { get; set; }
        public virtual DbSet<_02Pacijent> _02Pacijent { get; set; }
        public virtual DbSet<_02StanjePacijenta> _02StanjePacijenta { get; set; }
        public virtual DbSet<_02StatusSifrarnik> _02StatusSifrarnik { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<_02Doktori>(entity =>
            {
                entity.ToTable("02_doktori");

                entity.HasIndex(e => e.Ime)
                    .HasName("IX_doktori_1");

                entity.HasIndex(e => e.Prezime)
                    .HasName("IX_doktori");

                entity.HasIndex(e => e.Username)
                    .HasName("IX_doktori_2");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasColumnName("ime")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasColumnName("prezime")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<_02LokacijaPacijenta>(entity =>
            {
                entity.ToTable("02_lokacija_pacijenta");

                entity.HasIndex(e => e.KorisnikId)
                    .HasName("IX_lokacija_pacijenta");

                entity.HasIndex(e => e.Vrijeme)
                    .HasName("IX_lokacija_pacijenta_1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.KorisnikId).HasColumnName("korisnik_id");

                entity.Property(e => e.Lat)
                    .HasColumnName("lat")
                    .HasColumnType("decimal(10, 7)");

                entity.Property(e => e.Long)
                    .HasColumnName("long")
                    .HasColumnType("decimal(10, 7)");

                entity.Property(e => e.Vrijeme).HasColumnName("vrijeme");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p._02LokacijaPacijenta)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_lokacija_pacijenta_pacijent");
            });

            modelBuilder.Entity<_02Pacijent>(entity =>
            {
                entity.ToTable("02_pacijent");

                entity.HasIndex(e => e.Ime)
                    .HasName("IX_pacijent");

                entity.HasIndex(e => e.Oib)
                    .HasName("IX_pacijent_2");

                entity.HasIndex(e => e.Prezime)
                    .HasName("IX_pacijent_1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdresaSi)
                    .IsRequired()
                    .HasColumnName("adresa_si")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasColumnName("ime")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lat)
                    .HasColumnName("lat")
                    .HasColumnType("decimal(10, 7)");

                entity.Property(e => e.Long)
                    .HasColumnName("long")
                    .HasColumnType("decimal(10, 7)");

                entity.Property(e => e.Oib).HasColumnName("oib");

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasColumnName("prezime")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p._02Pacijent)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pacijent_Status_sifrarnik");
            });

            modelBuilder.Entity<_02StanjePacijenta>(entity =>
            {
                entity.ToTable("02_stanje_pacijenta");

                entity.HasIndex(e => e.KorisnikId)
                    .HasName("IX_stanje_pacijenta");

                entity.HasIndex(e => e.Vrijeme)
                    .HasName("IX_stanje_pacijenta_1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BolUMisicima).HasColumnName("bol_u_misicima");

                entity.Property(e => e.Kasalj).HasColumnName("kasalj");

                entity.Property(e => e.KorisnikId).HasColumnName("korisnik_id");

                entity.Property(e => e.Temperatura)
                    .HasColumnName("temperatura")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.Umor).HasColumnName("umor");

                entity.Property(e => e.Vrijeme).HasColumnName("vrijeme");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p._02StanjePacijenta)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_stanje_pacijenta_pacijent");
            });

            modelBuilder.Entity<_02StatusSifrarnik>(entity =>
            {
                entity.ToTable("02_status_sifrarnik");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasColumnName("naziv")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
