using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FinancialRiskAnalysis.Domain;

public static class ServiceCollectionExtensions
{
    public static void AddData<TDbContext>(
        this IServiceCollection serviceCollection,
        Action<DbContextOptionsBuilder>? optionsAction,
        ServiceLifetime contextLifetime = ServiceLifetime.Scoped,
        ServiceLifetime optionsLifetime = ServiceLifetime.Scoped)
        where TDbContext : DbContext
    {
        serviceCollection.AddScoped<IDataManager, DataManager>();
        serviceCollection.AddTransient<IUnitOfWork>(x => ActivatorUtilities.CreateInstance<UnitOfWork>(x));
        serviceCollection.TryAdd(ServiceDescriptor.Transient(typeof(IRepository<>), typeof(GenericRepository<>)));
        serviceCollection.AddScoped<IDataContext, DataContext<TDbContext>>();

        serviceCollection.AddDbContext<TDbContext>(optionsAction, contextLifetime, optionsLifetime);
    }
}
