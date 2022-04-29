using System.ComponentModel.DataAnnotations;

namespace OrderService.Dtos
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
       
    }
}
