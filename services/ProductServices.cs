using AutoMapper;
using CRUD.DTO;
using CRUD.Interfaces;
using CRUD.Models;
namespace CRUD.services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly ICategoryRepository _repo1;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repo, ICategoryRepository repo1, IMapper mapper)
        {
            _repo = repo;
            _repo1 = repo1;
            _mapper = mapper;
        }
       

        //public IEnumerable<Product> GetAll() => _repo.GetAll();
        public IEnumerable<ProductDto> GetAll()
        {
            var products = _repo.GetAll(); // Now includes Category
            return _mapper.Map<IEnumerable<ProductDto>>(products);

            /* return products.Select(p => new ProductDto
             {

                 Name = p.Name,
                 Price = p.Price,
                 CategoryId = p.CategoryId,
                 CategoryName = p.Category?.Name 
             });*/
        }



        public Product GetByIdAsync(int id) =>  _repo.GetByIdAsync(id);

        public ProductDto Create(ProductDto dto)
        {


            var category =  _repo1.GetCategoryById(dto.CategoryId);
            if (category == null)
                throw new ArgumentException(" CategoryId doesnt exist");

          /*  var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                CategoryId = dto.CategoryId
            };
           

            _repo.Add(product);

            // Fix: Return the created Product instead of ProductDto
           
            return new Product
            {
                
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId
            };
        } */
            var product = _mapper.Map<Product>(dto);
            _repo.Add(product);
            return _mapper.Map<ProductDto>(product);
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
