using System.ComponentModel.DataAnnotations;

namespace ShippingService.Models
{
    public class InVoice
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int ExternalID { get; set; }
        [Required]
        public string CodeInvoice { get; set; }
        public Shipping Shipping { get; set; }
    }
}
