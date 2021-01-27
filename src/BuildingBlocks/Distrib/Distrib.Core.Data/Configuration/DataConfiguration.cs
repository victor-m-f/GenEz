using Distrib.Helper.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Distrib.Core.Data.Configuration
{
    /// <summary>
    /// Exposes methods for configuring Data projects.
    /// </summary>
    public static class DataConfiguration
    {
        private const string DefaultConnection = "DefaultConnection";

        public static void UseDefaultConnection<TDbContext>(this IServiceCollection services, IConfiguration configuration, string schemaName = "dbo")
            where TDbContext : DbContext
        {
            var connectionString = configuration.GetConnectionString(DefaultConnection);

            if (SystemHelper.IsTesting)
            {
                _ = services.AddDbContext<TDbContext>(options =>
                    options.UseInMemoryDatabase(connectionString));
            }
            else
            {
                _ = services.AddDbContext<TDbContext>(options =>
                    options
                    .UseSqlServer(connectionString, x => x.MigrationsHistoryTable("tb_migration_history", schemaName)));
            }
        }
    }
}
