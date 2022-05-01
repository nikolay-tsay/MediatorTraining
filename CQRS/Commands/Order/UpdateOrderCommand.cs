using System.Collections.Generic;
using MediatR;
using WebShopDomain.Models;

namespace CQRS.Commands.Order
{
    public record UpdateOrderCommand(int Id, List<int> ProductIds) : IRequest<OrderDto>;
}