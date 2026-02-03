using Application.Services;
using Contractions.AdminSessions;
using Contractions.UserSessions;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAdminSessionService, AdminSessionService>();
        collection.AddScoped<IUserSessionService, UserSessionService>();
        
        return collection;
    }
}