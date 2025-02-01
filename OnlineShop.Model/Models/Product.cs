namespace OnlineShop.Model.Models
{
    public class Product : BaseModel
    {

        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required string Brand { get; set; }
        public required string Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}