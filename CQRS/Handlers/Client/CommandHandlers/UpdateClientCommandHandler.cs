using System;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Commands.Client;
using MediatR;
using WebShopDomain.Models;
using WebShopServices.Interfaces;

namespace CQRS.Handlers.Client.CommandHandlers
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, ClientDto>
    {
        private readonly IClientService _service;

        public UpdateClientCommandHandler(IClientService service)
        {
            _service = service;
        }

        public async Task<ClientDto> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
            => await _service.UpdateClient(request.Id, request.Client, cancellationToken);
    }
}