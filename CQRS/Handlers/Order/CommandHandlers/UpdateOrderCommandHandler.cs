using System.Threading;
using System.Threading.Tasks;
using CQRS.Commands.Order;
using MediatR;
using WebShopDomain.Models;
using WebShopServices.Interfaces;

namespace CQRS.Handlers.Order.CommandHandlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, OrderDto>
    {
        private readonly IOrderService _service;

        public UpdateOrderCommandHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<OrderDto> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
            => await _service.UpdateOrder(request.Id, request.ProductIds, cancellationToken);
    }
}