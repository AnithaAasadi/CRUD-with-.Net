using CRUD.DBContext;
using CRUD.DTO;
using CRUD.Interfaces;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Repositories
{
    public class EfProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public EfProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll() => _context.Products.Include(p=>p.Category).ToList();

        public  Product GetByIdAsync(int id) => _context.Products.Find(id);
        public Category GetCategoryById(int id)
        {
            return _context.Categories.Find(id);
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public bool Exists(int id) => _context.Products.Any(p => p.Id == id);
    }
}
