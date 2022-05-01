using System.Collections.Generic;

namespace WebShopDomain.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ProductDto> ProductList { get; set; }
    }
}