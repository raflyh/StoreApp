using System.ComponentModel.DataAnnotations;

namespace OrderService.Model
{
    public class InVoice
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string CodeInvoice { get; set; }
        [Required]
        public int TotalCost { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string OrderStatus { get; set; }
        public List<Product> Products { get; set; }

    }
}
