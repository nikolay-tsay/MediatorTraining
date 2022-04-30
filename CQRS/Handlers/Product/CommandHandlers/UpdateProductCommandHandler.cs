using System.Threading;
using System.Threading.Tasks;
using CQRS.Commands.Product;
using MediatR;
using WebShopDomain.Models;
using WebShopServices.Interfaces;

namespace CQRS.Handlers.Product.CommandHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IProductService _service;

        public UpdateProductCommandHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            => await _service.UpdateProduct(request.Id, request.Data, cancellationToken);
    }
}