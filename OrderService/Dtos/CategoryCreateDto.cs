using System.ComponentModel.DataAnnotations;

namespace OrderService.Dtos
{
    public class CategoryCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
