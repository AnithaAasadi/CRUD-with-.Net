using CRUD.Models;

namespace CRUD.Interfaces
{
    // Interfaces/IProductRepository.cs
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetByIdAsync(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        bool Exists(int id);
    }
}
