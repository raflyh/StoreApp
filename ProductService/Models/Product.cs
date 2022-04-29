using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductService.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }

    }
}
