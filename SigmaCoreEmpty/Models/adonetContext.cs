using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SigmaCoreEmpty.Models
{
    public partial class adonetContext : DbContext
    {
        public adonetContext()
        {
        }

        public adonetContext(DbContextOptions<adonetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animals> Animals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=adonet;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Animals>(entity =>
            {
                entity.Property(e => e.Height).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 4)");
            });
        }
    }
}
