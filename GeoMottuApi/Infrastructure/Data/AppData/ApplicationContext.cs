using GeoMottuApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeoMottuApi.Infrastructure.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MotoEntity>()
                .Property(m => m.Modelo)
                .HasConversion<string>();

            modelBuilder.Entity<MotoEntity>()
                .HasIndex(m => new { m.Placa, m.CodPlacaIot, m.Chassi })
                .IsUnique();
        }

        public DbSet<MotoEntity> Moto { get; set; }
    }
}
