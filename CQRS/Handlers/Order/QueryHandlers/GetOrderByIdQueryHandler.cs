using System.Threading;
using System.Threading.Tasks;
using CQRS.Queries.Order;
using MediatR;
using WebShopDomain.Models;
using WebShopServices.Interfaces;

namespace CQRS.Handlers.Order.QueryHandlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IOrderService _service;

        public GetOrderByIdQueryHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
            => await _service.GetOrderById(request.Id, cancellationToken);
    }
}