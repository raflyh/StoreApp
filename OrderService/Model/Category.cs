using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrderService.Model
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
