using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Z.EntityFramework.Extensions;

namespace WeatherTest.DataContext.DI
{
    public static class DbContextRegistration
    {
        private const string DATABASE_KEY = "WeatherTest";

        public static IServiceCollection AddDbContextServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(DATABASE_KEY);

            services.AddDbContextPool<WeatherTestDbContext>((provider, options) =>
            {
                options.UseMySql(connectionString);
            });

            services.AddDbContext<WeatherTestDbContext>();

            EntityFrameworkManager.ContextFactory = context =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<WeatherTestDbContext>();
                optionsBuilder.UseMySql(connectionString);
                return new WeatherTestDbContext(optionsBuilder.Options);
            };

            return services;
        }
    }
}
