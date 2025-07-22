using CRUD.Models;

namespace CRUD.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
       Category GetCategoryById(int id);
       // Category GetById(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
        bool Exists(int id);
    }
}
