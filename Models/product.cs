using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Product
    {
   
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1, 10000)]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
