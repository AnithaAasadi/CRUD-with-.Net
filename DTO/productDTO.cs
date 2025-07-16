using System.ComponentModel.DataAnnotations;

namespace CRUD.DTO
{
    // DTOs/ProductDto.cs
    public class ProductDto
    {
         //public int Id { get; set; }
        //public object Id { get; internal set; }
        [Required]
        public string Name { get; set; }
        [Range(1, 10000)]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
