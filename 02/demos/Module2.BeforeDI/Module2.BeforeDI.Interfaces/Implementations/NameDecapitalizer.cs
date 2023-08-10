using Module2.BeforeDI.Models.Model;

namespace Module2.BeforeDI.Interfaces.Implementations;

public class NameDecapitalizer : INameDecapitalizer
{
    private readonly IProductTransformationContext _productTransformationContext; 
    private readonly ICustomLogger _customLogger;

    public NameDecapitalizer(IProductTransformationContext productTransformationContext,
                             ICustomLogger customLogger)
    {
        _productTransformationContext = productTransformationContext
                                        ?? throw new ArgumentNullException(nameof(productTransformationContext));
        _customLogger = customLogger
                        ?? throw new ArgumentNullException(nameof(customLogger));
    }

    public void Execute()
    {
        var product = _productTransformationContext.GetProduct();

        if (product.Name.Any(x => char.IsUpper(x)))
        {
            _customLogger.LogInformation($"Decapitalizing the product name.");

            var newProduct = new Product(product.Id, product.Name.ToLowerInvariant(), product.Price, product.Stock);
            _productTransformationContext.SetProduct(newProduct);
        }
    }
}
