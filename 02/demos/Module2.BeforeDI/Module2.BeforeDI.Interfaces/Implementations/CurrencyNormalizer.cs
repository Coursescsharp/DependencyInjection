using Module2.BeforeDI.Models.Model;

namespace Module2.BeforeDI.Interfaces.Implementations;

public class CurrencyNormalizer : ICurrencyNormalizer
{
    private readonly IProductTransformationContext _productTransformationContext;
    private readonly ICustomLogger _customLogger;

    public CurrencyNormalizer(IProductTransformationContext productTransformationContext,
                              ICustomLogger customLogger)
    {
        _productTransformationContext = productTransformationContext ?? throw new ArgumentNullException(nameof(productTransformationContext));
        _customLogger = customLogger ?? throw new ArgumentNullException(nameof(customLogger));
    }

    public void Execute()
    {
        var product = _productTransformationContext.GetProduct();

        if (product.Price.IsoCurrency == Money.USD)
        {
            var newPrice = new Money(Money.EUR, product.Price.Amount * Money.USDToEURRate);
            
            _customLogger.LogInformation($"Product price recalculated. Old price: {product.Price}, new price: {newPrice}");
            
            var newProduct = new Product(product.Id, product.Name, newPrice, product.Stock);

            _productTransformationContext.SetProduct(newProduct);
        }
    }
}
