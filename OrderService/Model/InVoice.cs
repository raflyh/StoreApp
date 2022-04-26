namespace OrderService.Model
{
    public class InVoice
    {
        public int Id { get; set; }
        public int TotalCost { get; set; }
        public DateTime Date { get; set; }
        public string OrderStatus { get; set; }
        public Product Product { get; set; }
    }
}
