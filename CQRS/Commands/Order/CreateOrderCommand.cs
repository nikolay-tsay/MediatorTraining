using System.Collections.Generic;
using MediatR;

namespace CQRS.Commands.Order
{
    public record CreateOrderCommand(int ClientId, List<int> ProductIds) : IRequest;
}