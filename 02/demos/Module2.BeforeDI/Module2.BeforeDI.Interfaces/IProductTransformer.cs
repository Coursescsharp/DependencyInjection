using Module2.BeforeDI.Models.Model;

namespace Module2.BeforeDI.Interfaces;

public interface IProductTransformer
{
    Product ApplyTransformation(Product product);
}
