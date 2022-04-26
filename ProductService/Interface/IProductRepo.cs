using ProductService.Models;

namespace ProductService.Interface
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Category> GetAllCategories();
        Product GetById(int id);
        void Add(Product product);
        void Remove(int id);
        bool Update(int id,Product product);
        bool SaveChanges();
    }
}
