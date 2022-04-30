using System.Threading;
using System.Threading.Tasks;
using CQRS.Handlers.Product.CommandHandlers;
using MediatR;
using WebShopServices.Interfaces;

namespace CQRS.Commands.Product
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductService _service;

        public DeleteProductCommandHandler(IProductService service)
        {
            _service = service;
        }
        
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _service.DeleteProduct(request.Id, cancellationToken);
            
            return Unit.Value;
        }
    }
}