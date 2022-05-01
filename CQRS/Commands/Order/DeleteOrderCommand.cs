using MediatR;

namespace CQRS.Commands.Order
{
    public record DeleteOrderCommand(int Id) : IRequest;
}