using System.Threading;
using System.Threading.Tasks;
using CQRS.Commands.Client;
using MediatR;
using WebShopServices.Interfaces;

namespace CQRS.Handlers.Client.CommandHandlers
{
    public class AddClientHandler : IRequestHandler<AddClientCommand>
    {
        private readonly IClientService _service;

        public AddClientHandler(IClientService service)
        {
            _service = service;
        }

        public async Task<Unit> Handle(AddClientCommand request, CancellationToken cancellationToken)
        {
            await _service.AddClient(request.Client, cancellationToken);
            
            return Unit.Value;
        }
    }
}