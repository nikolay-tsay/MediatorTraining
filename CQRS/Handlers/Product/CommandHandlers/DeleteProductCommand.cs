using MediatR;

namespace CQRS.Handlers.Product.CommandHandlers
{
    public record DeleteProductCommand(int Id) : IRequest;
}