using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrderService.Model
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
        public int CategoryId { get; set; }
        [Required]
        public int InVoiceId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        [JsonIgnore]
        public InVoice inVoice { get; set; }
    }
}
