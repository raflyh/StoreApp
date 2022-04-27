using ProductService.Models;

namespace ProductService.Interface
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAllProducts();
        Product GetById(int id);
        void CreateProduct(Product product);
        void RemoveProduct(int id);
        Product UpdateProduct(int id,Product product);
        bool SaveChanges();
    }
}
