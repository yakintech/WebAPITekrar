namespace WebAPITekrar.Models.DTO.Product
{
    public class CreateProductResponseDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Stock { get; set; }

        public DateTime AddDate { get; set; }
    }
}
