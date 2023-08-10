using Module2.BeforeDI.Interfaces;
using Module2.BeforeDI.Source;
using Module2.BeforeDI.Target;

namespace Module2.BeforeDI;
/// <summary>
/// This class contains the main algorithm
/// and coordinates between reading and 
/// writing products.
/// </summary>
public class ProductImporter
{
    private readonly IProductSource _productSource;
    private readonly IProductTarget _productTarget;
    private readonly IImportStatistics _importStatistics;

    public ProductImporter(IProductSource productSource,
                           IProductTarget productTarget,
                           IImportStatistics importStatistics)
    {
        _productSource = productSource;
        _productTarget = productTarget;
        _importStatistics = importStatistics;
    }

    public void Run()
    {
        _productSource.Open();
        _productTarget.Open();

        while (_productSource.hasMoreProducts())
        {
            var product = _productSource.GetNextProduct();
            _productTarget.AddProduct(product);
        }

        _productSource.Close();
        _productTarget.Close();

        Console.WriteLine("Importing complete!");
        Console.WriteLine(_importStatistics.GetStatistics());
    }
}