using MediatR;
using WebShopDomain.Models;

namespace CQRS.Commands.Client
{
    public record AddClientCommand(ClientDto Client) : IRequest;
}