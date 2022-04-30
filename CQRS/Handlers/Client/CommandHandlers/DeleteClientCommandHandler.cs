using System.Threading;
using System.Threading.Tasks;
using CQRS.Commands.Client;
using MediatR;
using WebShopServices.Interfaces;

namespace CQRS.Handlers.Client.CommandHandlers
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand>
    {
        private readonly IClientService _service;

        public DeleteClientCommandHandler(IClientService service)
        {
            _service = service;
        }
        public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            await _service.DeleteClient(request.Id, cancellationToken);

            return Unit.Value;
        }
    }
}