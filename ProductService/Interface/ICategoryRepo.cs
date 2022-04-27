using ProductService.Models;

namespace ProductService.Interface
{
    public interface ICategoryRepo
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
        void Add(Category Category);
        bool SaveChanges();
    }
}
