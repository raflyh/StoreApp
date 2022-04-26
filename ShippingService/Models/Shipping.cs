using System.ComponentModel.DataAnnotations;

namespace ShippingService.Models
{
    public class Shipping
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string ShippingStatus { get; set; }
        [Required]
        public int InVoiceId { get; set; }
        public InVoice InVoice { get; set; }
    }
}
