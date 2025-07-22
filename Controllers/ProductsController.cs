using CRUD.DTO;
using CRUD.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Security.Claims;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        // Removed invalid code causing multiple errors
        // Console.WriteLine(this.Database.GetConnectionString());

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
      //  [Authorize (Roles ="Admin")]

        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var username = User.Identity?.Name;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            Console.WriteLine(role, username);
            var product = _service.GetByIdAsync(id);

            return product == null ? NotFound() : Ok(product);
        }


        [HttpPost]
        //  [Authorize(Roles = "Admin")]
        public IActionResult Create(ProductDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var product = _service.Create(dto);
                // return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
                return Ok(new
                {
                    message = "Product created",
                    data = new
                    {
                        Name = product.Name,
                        Price = product.Price,
                        CategoryId = product.CategoryId
                    }
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });  
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred", details = ex.Message });
            }

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return _service.Update(id, dto) ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _service.Delete(id) ? NoContent() : NotFound();
        }
    }
}
