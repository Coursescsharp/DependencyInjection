using Module2.BeforeDI.Models.Model;

namespace Module2.BeforeDI.Interfaces;

public interface IProductTransformationContext
{
    Product GetProduct();
    void SetProduct(Product product);
    bool IsProductChanged();
}
