using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebShopDomain.Models;

namespace WebShopServices.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetClientOrders(int clientId, CancellationToken cancellationToken);
        Task<IEnumerable<OrderDto>> GetOrders(CancellationToken cancellationToken);
        Task<OrderDto> GetOrderById(int id, CancellationToken cancellationToken);
        Task AddOrder(int clientId, IEnumerable<int> productIds, CancellationToken cancellationToken);
        Task<OrderDto> UpdateOrder(int id, IEnumerable<int> productIds, CancellationToken cancellationToken);
        Task DeleteOrder(int id, CancellationToken cancellationToken);
    }
}