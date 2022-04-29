using OrderService.Model;

namespace OrderService.Data
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        Product CreateProduct(Product prod);
    }
}
