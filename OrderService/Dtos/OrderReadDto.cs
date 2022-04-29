namespace OrderService.Dtos
{
    public class OrderReadDto
    {
        public int Id { get; set; }
      
        public string CodeInvoice { get; set; }
       
        public int TotalCost { get; set; }
        
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
    }
}
