using System.Collections.Generic;
using MediatR;
using WebShopDomain.Models;

namespace CQRS.Queries.Product
{
    public record GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>;
}