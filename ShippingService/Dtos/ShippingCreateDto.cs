using System.ComponentModel.DataAnnotations;

namespace ShippingService.Dtos
{
    public class ShippingCreateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ShippingStatus { get; set; }
        [Required]
        public int InVoiceId { get; set; }
    }
}
