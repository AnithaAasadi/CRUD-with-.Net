using CRUD.DTO;
using CRUD.Models;

namespace CRUD.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAll();
        Category GetCategoryById(int id);
        //Category GetById(int id);
        Category Create(CategoryDto dto);
        bool Update(int id, CategoryDto dto);
        bool Delete(int id);
    }

}
