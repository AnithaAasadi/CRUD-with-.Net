using CRUD.DTO;
using CRUD.Interfaces;
using CRUD.Models;

namespace CRUD.services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            var categories = _repo.GetAll();

            return categories.Select(p => new CategoryDto
            {
                Name = p.Name,
                ProductNames = p.Products.Select(p => p.Name).ToList()

            });
        }
       

        public Category GetCategoryById(int id) => _repo.GetCategoryById(id);

        public Category Create(CategoryDto dto)
        {
            var category = new Category { Name = dto.Name };
            _repo.Add(category);
            return category;
        }

        public bool Update(int id, CategoryDto dto)
        {
            if (!_repo.Exists(id)) return false;
            var category = new Category { Id = id, Name = dto.Name };
            _repo.Update(category);
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
