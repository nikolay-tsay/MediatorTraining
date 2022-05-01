using System.Threading;
using System.Threading.Tasks;
using CQRS.Commands.Order;
using MediatR;
using WebShopServices.Interfaces;

namespace CQRS.Handlers.Order.CommandHandlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderService _service;

        public DeleteOrderCommandHandler(IOrderService service)
        {
            _service = service;
        }
        
        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await _service.DeleteOrder(request.Id, cancellationToken);
            
            return Unit.Value;
        }
    }
}