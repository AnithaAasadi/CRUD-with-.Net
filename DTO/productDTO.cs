using System.ComponentModel.DataAnnotations;

namespace CRUD.DTO
{
    // DTOs/ProductDto.cs
    public class ProductDto
    {
        [Required]
        public string Name { get; set; }

        [Range(1, 10000)]
        public decimal Price { get; set; }
    }
}
