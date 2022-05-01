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
    public class OrderService : IOrderService
    {
        private readonly WebShopContext _db;
        private readonly IMapper _mapper;

        public OrderService(WebShopContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> GetClientOrders(int clientId, CancellationToken cancellationToken)
        {
            var orders = await _db.Orders
                .AsNoTracking()
                .Include(x => x.ProductList)
                .Where(x => x.ClientId == clientId)
                .ToListAsync(cancellationToken);
            
            return _mapper.Map<List<Order>, List<OrderDto>>(orders);
        }

        public async Task<IEnumerable<OrderDto>> GetOrders(CancellationToken cancellationToken)
        {
            var orders = await _db.Orders
                .AsNoTracking()
                .Include(x => x.ProductList)
                .ToListAsync(cancellationToken);
            
            return _mapper.Map<List<Order>, List<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetOrderById(int id, CancellationToken cancellationToken)
        {
            var order = await _db.Orders
                .Include(x => x.ProductList)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<OrderDto>(order);
        }

        public async Task AddOrder(int clientId, IEnumerable<int> productIds, CancellationToken cancellationToken)
        {
            var newOrder = new Order
            {
                Client = await GetOrderClient(clientId, cancellationToken),
                ProductList = await GetOrderProducts(productIds, cancellationToken),
            };
            newOrder.TotalPrice = newOrder.ProductList.Sum(x => x.Price);

            _db.Orders.Add(newOrder);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<OrderDto> UpdateOrder(int id, IEnumerable<int> productIds, CancellationToken cancellationToken)
        {
            var order = await _db.Orders
                .Include(x => x.ProductList)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            if (order == null)
            {
                throw new Exception();
            }

            //Not very good, but it is demo, so whatever
            order.ProductList.Clear();
            order.ProductList = await GetOrderProducts(productIds, cancellationToken);
            order.TotalPrice = order.ProductList.Sum(x => x.Price);

            await _db.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OrderDto>(order);
        }

        public async Task DeleteOrder(int id, CancellationToken cancellationToken)
        {
            var order = await _db.Orders
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            if (order == null)
            {
                throw new Exception();
            }

            _db.Orders.Remove(order);
            await _db.SaveChangesAsync(cancellationToken);
        }
        
        private async Task<List<Product>> GetOrderProducts(IEnumerable<int> productIds, CancellationToken cancellationToken)
        {
            var products = new List<Product>();
            foreach (var id in productIds)
            {
                var product = await _db.Products
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync(cancellationToken);

                if (product != null)
                {
                    products.Add(product);
                }
            }

            return products;
        }

        private async Task<Client> GetOrderClient(int clientId, CancellationToken cancellationToken)
        {
            var client = await _db.Clients
                .Where(x => x.Id == clientId)
                .FirstOrDefaultAsync(cancellationToken);

            if (client == null)
            {
                throw new Exception();
            }

            return client;
        }
    }
}