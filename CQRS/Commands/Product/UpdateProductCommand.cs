using MediatR;
using WebShopDomain.Models;

namespace CQRS.Commands.Product
{
    public record UpdateProductCommand(int Id, ProductDto Data) : IRequest<ProductDto>;
}