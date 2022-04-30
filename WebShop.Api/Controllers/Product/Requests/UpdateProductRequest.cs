namespace WebShopApi.Controllers.Product.Requests
{
    public class UpdateProductRequest
    {
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
    }
}