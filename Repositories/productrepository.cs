using CRUD.Interfaces;
using CRUD.Models;

namespace CRUD.Repositories
{
    // Repositories/InMemoryProductRepository.cs
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();

        public IEnumerable<Product> GetAll() => _products;
       public Product GetByIdAsync(int id) => _products.FirstOrDefault(p => p.Id == id);
        public void Add(Product product) => _products.Add(product);
        public void Update(Product product)
        {
            var index = _products.FindIndex(p => p.Id == product.Id);
            if (index >= 0)
                _products[index] = product;
        }
        public void Delete(int id) => _products.RemoveAll(p => p.Id == id);
        public bool Exists(int id) => _products.Any(p => p.Id == id);
    }
}
