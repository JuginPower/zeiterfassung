using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ZeitApi.Data.Models
{
    public partial class arbeitContext : DbContext
    {
        public arbeitContext()
        {
        }

        public arbeitContext(DbContextOptions<arbeitContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arbeiter> Arbeiters { get; set; }
        public virtual DbSet<Zeitstempel> Zeitstempels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("DataSource=C:/Users/kraft/Desktop/meine_Programme/projects/ASP.NET-Web-Api/ZeitApi/ZeitApi.Data/Models/arbeit.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arbeiter>(entity =>
            {
                entity.HasKey(e => e.Personid);

                entity.ToTable("arbeiter");

                entity.Property(e => e.Personid)
                    .ValueGeneratedNever()
                    .HasColumnName("personid");

                entity.Property(e => e.Nachname)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("nachname");

                entity.Property(e => e.Password)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("username");

                entity.Property(e => e.Vorname)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("vorname");
            });

            modelBuilder.Entity<Zeitstempel>(entity =>
            {
                entity.HasKey(e => e.Personid);

                entity.ToTable("zeitstempel");

                entity.Property(e => e.Personid)
                    .ValueGeneratedNever()
                    .HasColumnName("personid");

                entity.Property(e => e.Abstart).HasColumnName("abstart");

                entity.Property(e => e.Abwesenheit).HasColumnName("abwesenheit");

                entity.Property(e => e.Arbeitbeginn).HasColumnName("arbeitbeginn");

                entity.Property(e => e.Arbeitende).HasColumnName("arbeitende");

                entity.Property(e => e.Datum)
                    .HasColumnType("date")
                    .HasColumnName("datum");

                entity.Property(e => e.Pausenbeginn).HasColumnName("pausenbeginn");

                entity.Property(e => e.Pausenende).HasColumnName("pausenende");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
