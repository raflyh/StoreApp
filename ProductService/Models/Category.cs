using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductService.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
