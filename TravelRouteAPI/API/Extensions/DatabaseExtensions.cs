using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

internal static class DatabaseExtensions
{
    internal static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseNpgsql(
                DbContextFactory.GetConnectionString(
                    DbContextFactory.GetConfiguration(Directory.GetCurrentDirectory())));
            
#if DEBUG
            opt.EnableDetailedErrors();
            opt.EnableSensitiveDataLogging();
#endif
        });

        return services;
    }
}