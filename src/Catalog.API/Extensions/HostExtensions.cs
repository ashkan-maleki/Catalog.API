using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Catalog.API.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase<TContext>(
            this IHost host,
            int retry = 0)
            where TContext : DbContext
        {
            int retryForAvailability = retry;
            using IServiceScope scope = host.Services.CreateScope();
            IServiceProvider services = scope.ServiceProvider;
            ILogger<TContext> logger = services
                .GetRequiredService<ILogger<TContext>>();
            TContext context = services.GetService<TContext>()!;


            try
            {
                logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(TContext).Name);

                context.Database.Migrate();

                logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(TContext).Name);
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(TContext).Name);

                if (retryForAvailability < 50)
                {
                    retryForAvailability++;
                    System.Threading.Thread.Sleep(2000);
                    MigrateDatabase<TContext>(host, retryForAvailability);
                }
            }

            return host;
        }

        private static void InvokeSeeder<TContext>(
            Action<TContext, IServiceProvider> seeder,
            TContext context,
            IServiceProvider services)
            where TContext : DbContext
        {
            seeder(context, services);
        }
    }

    
}
