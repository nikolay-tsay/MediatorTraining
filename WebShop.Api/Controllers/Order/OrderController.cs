using System.Threading.Tasks;
using CQRS.Commands.Order;
using CQRS.Queries.Order;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebShopApi.Controllers.Order.Requests;

namespace WebShopApi.Controllers.Order
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var result = await _mediator.Send(new GetOrdersQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("{clientId:int}")]
        public async Task<IActionResult> GetClientOrders(int clientId)
        {
            var result = await _mediator.Send(new GetClientOrdersQuery(clientId));
            return Ok(result);
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            await _mediator.Send(new CreateOrderCommand(request.ClientId, request.ProductIds));
            return Ok();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderRequest request)
        {
            var result = await _mediator.Send(new UpdateOrderCommand(id, request.ProductIds));
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _mediator.Send(new DeleteOrderCommand(id));
            return Ok();
        }
    }
}