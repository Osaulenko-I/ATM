using Microsoft.Extensions.DependencyInjection;

namespace Http;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection collection)
    {
        collection.AddControllers();
        return collection;
    }
}