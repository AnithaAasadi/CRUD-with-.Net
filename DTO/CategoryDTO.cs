using System.ComponentModel.DataAnnotations;

namespace CRUD.DTO
{
    public class CategoryDto
    {
        [Required]
        public string Name { get; set; }

        public List<string> ProductNames { get; set; } = new();

    }
}
