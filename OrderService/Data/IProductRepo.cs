using OrderService.Model;

namespace OrderService.Data
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductByName(string name);
        Product CreateProduct(Product prod);
    }
}
