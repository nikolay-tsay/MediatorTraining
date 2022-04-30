using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebShopDomain.Models;

namespace WebShopServices.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts(CancellationToken cancellationToken);
        Task<ProductDto> GetProductById(int id, CancellationToken cancellationToken);
        Task AddProduct(ProductDto data, CancellationToken cancellationToken);
        Task<ProductDto> UpdateProduct(int id, ProductDto data, CancellationToken cancellationToken);
        Task DeleteProduct(int id, CancellationToken cancellationToken);
    }
}