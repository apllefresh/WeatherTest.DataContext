using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WeatherTest.DataContext
{
    // only for migrations
    internal class WeatherTestDbContextFactory : IDesignTimeDbContextFactory<WeatherTestDbContext>
    {
        public WeatherTestDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WeatherTestDbContext>();

            var connectionString = "server=localhost;user id=user;password=123456;database=weathertest";

            optionsBuilder.UseMySql(connectionString);

            return new WeatherTestDbContext(optionsBuilder.Options);
        }
    }
}
