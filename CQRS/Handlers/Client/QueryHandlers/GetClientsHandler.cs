using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Queries.Client;
using MediatR;
using WebShopDomain.Models;
using WebShopServices.Interfaces;

namespace CQRS.Handlers.Client.QueryHandlers
{
    public class GetClientsHandler : IRequestHandler<GetClientsQuery, IEnumerable<ClientDto>>
    {
        private readonly IClientService _service;

        public GetClientsHandler(IClientService service)
        {
            _service = service;
        }
        public async Task<IEnumerable<ClientDto>> Handle(GetClientsQuery request, CancellationToken cancellationToken) 
            =>  await _service.GetClients(cancellationToken);
    }
}