using System.Threading;
using System.Threading.Tasks;
using CQRS.Queries.Client;
using MediatR;
using WebShopDomain.Models;
using WebShopServices.Interfaces;

namespace CQRS.Handlers.Client.QueryHandlers
{
    public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, ClientDto>
    {
        private readonly IClientService _service;

        public GetClientByIdHandler(IClientService service)
        {
            _service = service;
        }

        public async Task<ClientDto> Handle(GetClientByIdQuery request, CancellationToken cancellationToken) 
            => await _service.GetClientById(request.Id, cancellationToken);
    }
}