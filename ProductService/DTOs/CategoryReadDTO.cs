namespace ProductService.DTOs
{
    public class CategoryReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductReadDTO> Products { get; set; }
    }
}
