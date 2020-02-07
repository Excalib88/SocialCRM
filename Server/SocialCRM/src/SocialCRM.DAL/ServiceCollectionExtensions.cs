using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialCRM.DAL.Repositories;

namespace SocialCRM.DAL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNpgsql(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDbContext<DataContext>(builder =>
                {
                    builder
                        .EnableSensitiveDataLogging(true)
                        .UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                            x => x.MigrationsAssembly("SocialCRM.DAL.Migrations")
                                .CommandTimeout((int) TimeSpan.FromMinutes(10).TotalSeconds));
                })
                .AddScoped<IDbRepository, DbRepository>(
                    provider => new DbRepository(provider.GetRequiredService<DataContext>()));
        }
    }
}