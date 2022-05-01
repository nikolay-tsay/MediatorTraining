using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Queries.Order;
using MediatR;
using WebShopDomain.Models;
using WebShopServices.Interfaces;

namespace CQRS.Handlers.Order.QueryHandlers
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<OrderDto>>
    {
        private readonly IOrderService _service;

        public GetOrdersQueryHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
            => await _service.GetOrders(cancellationToken);
    }
}