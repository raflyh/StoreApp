using System.ComponentModel.DataAnnotations;

namespace ShippingService.Models
{
    public class Shipping
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public int InVoiceId { get; set; }
        public InVoice inVoice { get; set; }
    }
}
