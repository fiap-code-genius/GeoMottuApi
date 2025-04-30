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
        }

        public DbSet<MotoEntity> Moto { get; set; }
    }
}
