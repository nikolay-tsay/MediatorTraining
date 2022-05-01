using System.Collections.Generic;

namespace WebShopApi.Controllers.Order.Requests
{
    public class CreateOrderRequest
    {
        public int ClientId { get; set; }
        public List<int> ProductIds { get; set; } = null!;
    }
}