using Microsoft.EntityFrameworkCore;
using WeatherTest.DataContext.Entities;

namespace WeatherTest.DataContext
{
    public class WeatherTestDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }

        public DbSet<Temperature> Temperatures { get; set; }

        public WeatherTestDbContext(DbContextOptions<WeatherTestDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Url).IsRequired();
                entity
                    .HasIndex(e => e.Name)
                    .IsUnique();
                entity
                    .HasIndex(e => e.Url)
                    .IsUnique();
            });

            modelBuilder.Entity<Temperature>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DateTime).IsRequired();
                entity.Property(e => e.Degree).IsRequired();
                entity.Property(e => e.CityId).IsRequired();

                entity.HasIndex(e => new
                {
                    e.CityId,
                    e.DateTime
                })
                   .IsUnique();

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Temperatures);
            });
        }
    }
}