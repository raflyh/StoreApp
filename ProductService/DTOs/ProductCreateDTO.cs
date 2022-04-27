using System.ComponentModel.DataAnnotations;

namespace ProductService.DTOs
{
    public class ProductCreateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public int CategoryId { get; set; }
    }
}
