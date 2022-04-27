using Microsoft.EntityFrameworkCore;
using ProductService.Interface;
using ProductService.Models;

namespace ProductService.Data
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _context;

        public CategoryRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.OrderBy(s => s.Name).ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(p => p.Id == id);
        }

        public Category GetCategoryByName(string name)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Name == name);
            return category;
        }

        public Category GetCategoryWithProducts(string name)
        {
            var category = _context.Categories.Include(s => s.Products).FirstOrDefault(c => c.Name == name);
            return category;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
