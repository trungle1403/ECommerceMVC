namespace ECommerceMVC.Models
{
    public class ProductsModel
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }

        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }
    }
}
