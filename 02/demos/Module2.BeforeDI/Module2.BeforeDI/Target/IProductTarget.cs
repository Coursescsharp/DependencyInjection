using Module2.BeforeDI.Models.Model;

namespace Module2.BeforeDI.Target;

public interface IProductTarget
{
    void Open();
    void AddProduct(Product product);
    void Close();
}
