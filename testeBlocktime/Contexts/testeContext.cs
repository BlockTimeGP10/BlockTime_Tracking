using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using testeBlocktime.Domains;

#nullable disable

namespace testeBlocktime.Contexts
{
    public partial class testeContext : DbContext
    {
        public testeContext()
        {
        }

        public testeContext(DbContextOptions<testeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Lugar> Lugars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=NOTE0113D2\\SQLEXPRESS; initial catalog=LOCAIS; user Id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Lugar>(entity =>
            {
                entity.HasKey(e => e.IdLugar)
                    .HasName("PK__LUGAR__F7460D5FA60A7E5E");

                entity.ToTable("LUGAR");

                entity.Property(e => e.IdLugar).HasColumnName("idLugar");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
