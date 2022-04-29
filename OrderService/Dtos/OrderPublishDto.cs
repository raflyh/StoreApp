namespace OrderService.Dtos
{
    public class OrderPublishDto
    {
        public int Id { get; set; }

        public string CodeInvoice { get; set; }

        public int Price { get; set; }

        public DateTime Date { get; set; }
        public string Event { get; set; }
    }
}
