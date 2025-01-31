namespace OnlineShop.Model.Models
{
    public class Product : BaseModel
    {

        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}