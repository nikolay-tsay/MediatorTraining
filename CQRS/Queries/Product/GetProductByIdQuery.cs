using MediatR;
using WebShopDomain.Models;

namespace CQRS.Queries.Product
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductDto>;
}