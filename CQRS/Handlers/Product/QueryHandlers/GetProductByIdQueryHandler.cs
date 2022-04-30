using System.Threading;
using System.Threading.Tasks;
using CQRS.Queries.Product;
using MediatR;
using WebShopDomain.Models;
using WebShopServices.Interfaces;

namespace CQRS.Handlers.Product.QueryHandlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductService _service;

        public GetProductByIdQueryHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            => await _service.GetProductById(request.Id, cancellationToken);
    }
}