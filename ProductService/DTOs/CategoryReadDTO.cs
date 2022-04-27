namespace ProductService.DTOs
{
    public class CategoryReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductReadDTO> productReadDTOs { get; set; }
    }
}
