namespace API.Extensions;

internal static class SwaggerExtensions
{
    internal static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(opt =>
            {
                opt.CustomSchemaIds(x => x.FullName);
            });
        
        return services;
    }
}