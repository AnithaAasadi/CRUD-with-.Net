using CRUD.DTO;
using CRUD.Models;

namespace CRUD.Interfaces
{
    // Interfaces/IProductService.cs
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        Product Create(ProductDto dto);
        bool Update(int id, ProductDto dto);
        bool Delete(int id);
    }

    
}
