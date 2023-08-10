using Microsoft.Extensions.DependencyInjection;
using Module2.BeforeDI.Models.Model;

namespace Module2.BeforeDI.Interfaces.Implementations;

public class ProductTransformer : IProductTransformer
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly IImportStatistics _importStatistics;
    private readonly ICustomLogger _customLogger;

    public ProductTransformer(IServiceScopeFactory serviceScopeFactory,
                              IImportStatistics importStatistics,
                              ICustomLogger customLogger)
    {
        _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        _importStatistics = importStatistics ?? throw new ArgumentNullException(nameof(importStatistics));
        _customLogger = customLogger ?? throw new ArgumentNullException(nameof(customLogger));
    }

    public Product ApplyTransformation(Product product)
    {
        if (product is null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        using (var scope = _serviceScopeFactory.CreateScope())
        {
            _customLogger.LogInformation($"Starting the transformation of product {product.Name}.");
            
            var transformationContext = scope.ServiceProvider.GetRequiredService<IProductTransformationContext>();
            var nameCapitalizer = scope.ServiceProvider.GetRequiredService<INameDecapitalizer>();
            var currencyNormalizer = scope.ServiceProvider.GetRequiredService<ICurrencyNormalizer>();


            transformationContext.SetProduct(product);
            nameCapitalizer.Execute();
            currencyNormalizer.Execute();

            if (transformationContext.IsProductChanged())
            {
                _importStatistics.IncrementTransformationCount();
            }
            
            return transformationContext.GetProduct();
        }
    }
}
