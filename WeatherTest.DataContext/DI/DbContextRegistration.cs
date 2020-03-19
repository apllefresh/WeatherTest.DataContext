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

            /*
             https://entityframework-extensions.net/context-factory
             The context factory is required to provide a working context to the EFE library. 
             For example, this context will be used to retrieve some information by attaching/detaching entities without impacting the current context.
             If your context has a default constructor (no parameter), specifying a context factory may be optional unless your context requires some special configuration.
             */
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