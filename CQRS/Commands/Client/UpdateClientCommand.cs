using MediatR;
using WebShopDomain.Models;

namespace CQRS.Commands.Client
{
    public record UpdateClientCommand(int Id, ClientDto Client) : IRequest<ClientDto>;
}