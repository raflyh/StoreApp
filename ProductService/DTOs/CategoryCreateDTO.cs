using System.ComponentModel.DataAnnotations;

namespace ProductService.DTOs
{
    public class CategoryCreateDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
