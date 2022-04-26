using System.ComponentModel.DataAnnotations;

namespace ShippingService.Dtos
{
    public class ShippingCreateDto
    {
        [Required]
        public string ShippingStatus { get; set; }
        [Required]
        public int InVoiceId { get; set; }
    }
}
