namespace OrderService.Model
{
    public class Product
    {
        public int Id { get; set; }
        public int ExternalId { get; set; }
        public InVoice InVoice { get; set; }
    }
}
