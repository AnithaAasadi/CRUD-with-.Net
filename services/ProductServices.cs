using CRUD.DTO;
using CRUD.Interfaces;
using CRUD.Models;

namespace CRUD.services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Product> GetAll() => _repo.GetAll();

        public Product GetById(int id) => _repo.GetById(id);

        public Product Create(ProductDto dto)
        {
            var product = new Product
            {
                Id = new Random().Next(1, 10000),
                Name = dto.Name,
                Price = dto.Price
            };
            _repo.Add(product);
            return product;
        }

        public bool Update(int id, ProductDto dto)
        {
            if (!_repo.Exists(id)) return false;
            var product = new Product { Id = id, Name = dto.Name, Price = dto.Price };
            _repo.Update(product);
            return true;
        }

        public bool Delete(int id)
        {
            if (!_repo.Exists(id)) return false;
            _repo.Delete(id);
            return true;
        }
    }

}
