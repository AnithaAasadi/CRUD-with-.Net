using CRUD.DBContext;
using CRUD.Interfaces;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Repositories
{
    public class EfCategoryRepository : ICategoryRepository
    {
        private readonly ProductDbContext _context;

        public EfCategoryRepository(ProductDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll() => _context.Categories.Include(p=>p.Products).ToList();
        public Category GetCategoryById(int id)
        {
            return _context.Categories.Find(id);
        }
        public Category GetById(int id) => _context.Categories.Find(id);
        public void Add(Category category) { _context.Categories.Add(category); _context.SaveChanges(); }
        public void Update(Category category) { _context.Categories.Update(category); _context.SaveChanges(); }
        public void Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null) { _context.Categories.Remove(category); _context.SaveChanges(); }
        }
        public bool Exists(int id) => _context.Categories.Any(c => c.Id == id);
    }
}
