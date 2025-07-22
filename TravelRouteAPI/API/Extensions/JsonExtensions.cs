using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

namespace API.Extensions;

internal static class JsonExtensions
{
    internal static IServiceCollection AddJsonSerializer(this IServiceCollection services)
    {
        services.Configure<JsonOptions>(opt =>
        {
            opt.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

        services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(opt =>
        {
            opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        
        return services;
    }
}