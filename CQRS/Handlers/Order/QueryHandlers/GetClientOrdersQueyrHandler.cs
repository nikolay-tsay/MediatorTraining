using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Queries.Order;
using MediatR;
using WebShopDomain.Models;
using WebShopServices.Interfaces;

namespace CQRS.Handlers.Order.QueryHandlers
{
    public class GetClientOrdersQueyrHandler : IRequestHandler<GetClientOrdersQuery, IEnumerable<OrderDto>>
    {
        private readonly IOrderService _service;

        public GetClientOrdersQueyrHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetClientOrdersQuery request, CancellationToken cancellationToken)
            => await _service.GetClientOrders(request.ClientId, cancellationToken);
    }
}