using System.ComponentModel.DataAnnotations;

namespace OrderService.Model
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name {get; set;}
        public double Price { get; set; }
        public InVoice InVoice { get; set; }
    }
}
