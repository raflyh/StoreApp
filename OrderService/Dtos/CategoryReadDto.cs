namespace OrderService.Dtos
{
    public class CategoryReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductReadDto> Products { get; set; }
    }
}
