using Microsoft.Extensions.DependencyInjection;
using Module2.BeforeDI.Interfaces.Implementations;

namespace Module2.BeforeDI.Interfaces.Extensions;

public static class ResolversExtensions
{
    public static IServiceCollection AddResolvers(this IServiceCollection services)
    {
        // All these three types are instantiated exactly once for each product,
        // especially as it's reused by the ProductTransformer, NameDecapitalizer
        // and CurrencyNormalizer. And all three need the same instance.
        return services
            .AddScoped<IProductTransformationContext, ProductTransformationContext>()
            .AddScoped<INameDecapitalizer, NameDecapitalizer>()
            .AddScoped<ICurrencyNormalizer, CurrencyNormalizer>()
            .AddSingleton<IImportStatistics, ImportStatistics>()
            .AddTransient<IProductTransformer, ProductTransformer>();
    }
}
