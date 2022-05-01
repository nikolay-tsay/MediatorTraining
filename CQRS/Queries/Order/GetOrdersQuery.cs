using System.Collections.Generic;
using MediatR;
using WebShopDomain.Models;

namespace CQRS.Queries.Order
{
    public record GetOrdersQuery : IRequest<IEnumerable<OrderDto>>;
}