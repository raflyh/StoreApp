using ProductService.Interface;
using ProductService.Models;

namespace ProductService.Data
{
    public class CategoryRepo : ICategoryRepo
    {
        public void Add(Category Category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
