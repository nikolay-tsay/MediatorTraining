using MediatR;

namespace CQRS.Commands.Client
{
    public record DeleteClientCommand(int Id) : IRequest;
}