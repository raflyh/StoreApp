using ProductService.Models;

namespace ProductService.Interface
{
    public interface ICategoryRepo
    {
        IEnumerable<Category> GetAllCategories();
        Category GetById(int id);
        Category GetCategoryWithProducts(string name);
        Category GetCategoryByName(string name);
        void CreateCategory(Category category);
        bool SaveChanges();
    }
}
