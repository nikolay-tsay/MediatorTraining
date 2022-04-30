using MediatR;
using WebShopDomain.Models;

namespace CQRS.Queries.Client
{
    public record GetClientByIdQuery(int Id) : IRequest<ClientDto>;
}