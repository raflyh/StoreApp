using System.ComponentModel.DataAnnotations;

namespace OrderService.Dtos
{
    public class OrderCreateDto
    {
        [Required]
        public string CodeInVoice { get; set; }
        
        [Required]
        public int TotalCost { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
