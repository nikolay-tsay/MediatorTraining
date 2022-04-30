using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Queries.Product;
using MediatR;
using WebShopDomain.Models;
using WebShopServices.Interfaces;

namespace CQRS.Handlers.Product.QueryHandlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductService _service;

        public GetAllProductsQueryHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            => await _service.GetProducts(cancellationToken);
    }
}