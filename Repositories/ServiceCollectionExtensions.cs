using Abstractions.Persistence;
using Abstractions.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Persistence;
using Repositories.Repositories;

namespace Repositories;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection)
    {
        collection.AddScoped<IPersistenceContext, PersistenceContextInMemory>();

        collection.AddSingleton<IAccountRepository, AccountInMemoryRepository>();
        collection.AddSingleton<IAdminSessionRepository, AdminSessionRepository>();
        collection.AddSingleton<IUserSessionRepository, UserSessionInMemoryRepository>();
        collection.AddSingleton<ITransactionRepository, TransactionInMemoryRepository>();

        return collection;
    }
}