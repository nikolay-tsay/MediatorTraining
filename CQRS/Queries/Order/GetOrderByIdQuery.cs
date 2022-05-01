using MediatR;
using WebShopDomain.Models;

namespace CQRS.Queries.Order
{
    public record GetOrderByIdQuery(int Id) : IRequest<OrderDto>;
}