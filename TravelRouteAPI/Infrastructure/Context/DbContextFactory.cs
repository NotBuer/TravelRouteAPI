using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context;

public class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var configuration = GetConfiguration();
        var connectionString = GetConnectionString(configuration);
        
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        builder.UseNpgsql(connectionString);
#if DEBUG
        builder.EnableDetailedErrors();
        builder.EnableSensitiveDataLogging();      
#endif
        
        return new AppDbContext(builder.Options);
    }
    
    private static IConfigurationRoot GetConfiguration() =>
        new ConfigurationBuilder()
            .SetBasePath(@$"{Directory.GetParent(Directory.GetCurrentDirectory())}\API")
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
    
    public static IConfigurationRoot GetConfiguration(string directory) => 
        new ConfigurationBuilder()
            .SetBasePath(directory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
    
    public static string GetConnectionString(IConfigurationRoot configuration) =>
        configuration.GetConnectionString(nameof(AppDbContext)) ?? throw new InvalidOperationException($"Connection string {nameof(AppDbContext)} not found.");
}