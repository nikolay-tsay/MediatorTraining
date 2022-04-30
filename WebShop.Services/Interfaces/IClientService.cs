using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebShopDomain.Models;

namespace WebShopServices.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetClients(CancellationToken cancellationToken);
        Task<ClientDto> GetClientById(int id, CancellationToken cancellationToken);
        Task AddClient(ClientDto data, CancellationToken cancellationToken);
        Task<ClientDto> UpdateClient(int id, ClientDto data, CancellationToken cancellationToken);
        Task DeleteClient(int id, CancellationToken cancellationToken);
    }
}