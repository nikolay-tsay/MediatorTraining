using MediatR;
using WebShopDomain.Models;

namespace CQRS.Commands.Product
{
    public record AddProductCommand(ProductDto Data) : IRequest;
}