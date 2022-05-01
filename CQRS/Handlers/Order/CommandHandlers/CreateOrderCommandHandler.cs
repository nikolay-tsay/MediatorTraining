using System.Threading;
using System.Threading.Tasks;
using CQRS.Commands.Order;
using MediatR;
using WebShopServices.Interfaces;

namespace CQRS.Handlers.Order.CommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderService _service;

        public CreateOrderCommandHandler(IOrderService service)
        {
            _service = service;
        }
        
        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            await _service.AddOrder(request.ClientId, request.ProductIds, cancellationToken);
            
            return Unit.Value;
        }
    }
}