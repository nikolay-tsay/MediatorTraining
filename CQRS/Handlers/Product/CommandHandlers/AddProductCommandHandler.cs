using System.Threading;
using System.Threading.Tasks;
using CQRS.Commands.Product;
using MediatR;
using WebShopServices.Interfaces;

namespace CQRS.Handlers.Product.CommandHandlers
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand>
    {
        private readonly IProductService _service;

        public AddProductCommandHandler(IProductService service)
        {
            _service = service;
        }
        
        public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _service.AddProduct(request.Data, cancellationToken);
            
            return Unit.Value;
        }
    }
}