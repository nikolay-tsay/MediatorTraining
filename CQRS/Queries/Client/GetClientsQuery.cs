using System.Collections.Generic;
using MediatR;
using WebShopDomain.Models;

namespace CQRS.Queries.Client
{
    public record GetClientsQuery : IRequest<IEnumerable<ClientDto>>;
}