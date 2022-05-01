using System.Collections.Generic;

namespace WebShopApi.Controllers.Order.Requests
{
    public class UpdateOrderRequest
    {
        public List<int> ProductIds { get; set; } = null!;
    }
}