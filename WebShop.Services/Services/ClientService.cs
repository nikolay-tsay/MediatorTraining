using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebShopDomain.Contexts;
using WebShopDomain.Entities;
using WebShopDomain.Models;
using WebShopServices.Interfaces;

namespace WebShopServices.Services
{
    public class ClientService : IClientService
    {
        private readonly WebShopContext _db;
        private readonly IMapper _mapper;

        public ClientService(WebShopContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<ClientDto>> GetClients(CancellationToken cancellationToken)
        {
            var clients = await _db.Clients.ToListAsync(cancellationToken);
            return _mapper.Map<List<Client>, List<ClientDto>>(clients);
        }

        public async Task<ClientDto> GetClientById(int id, CancellationToken cancellationToken)
        {
            var client = await _db.Clients
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<ClientDto>(client);
        }

        public async Task AddClient(ClientDto data, CancellationToken cancellationToken)
        {
            var client = new Client
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                City = data.City,
                Email = data.Email,
                HouseNumber = data.HouseNumber,
                LandRegistryNumber = data.LandRegistryNumber,
                PhoneNumber = data.PhoneNumber,
                PostCode = data.PostCode,
                Street = data.Street
            };

            _db.Clients.Add(client);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<ClientDto> UpdateClient(int id, ClientDto data, CancellationToken cancellationToken)
        {
            var client = await _db.Clients
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
            
            if (client == null)
            {
                throw new Exception();
            }

            client.Email = data.Email;
            client.PhoneNumber = data.PhoneNumber;
            client.Street = data.Street;
            client.HouseNumber = data.HouseNumber;
            client.LandRegistryNumber = data.LandRegistryNumber;
            client.City = data.City;
            client.PostCode = data.PostCode;

            await _db.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ClientDto>(client);
        }

        public async Task DeleteClient(int id, CancellationToken cancellationToken)
        {
            var client = await _db.Clients
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync(cancellationToken);
            
            if (client == null)
            {
                throw new Exception();
            }

            _db.Clients.Remove(client);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}