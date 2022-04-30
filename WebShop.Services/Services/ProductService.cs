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
    public class ProductService : IProductService
    {
        private readonly WebShopContext _db;
        private readonly IMapper _mapper;

        public ProductService(WebShopContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<ProductDto>> GetProducts(CancellationToken cancellationToken)
        {
            var products = await _db.Products.ToListAsync(cancellationToken);
            return _mapper.Map<List<Product>, List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductById(int id, CancellationToken cancellationToken)
        {
            var product = await _db.Products
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task AddProduct(ProductDto data, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price
            };

            _db.Products.Add(product);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<ProductDto> UpdateProduct(int id, ProductDto data, CancellationToken cancellationToken)
        {
            var product = await _db.Products
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            if (product == null)
            {
                throw new Exception();
            }

            product.Name = data.Name;
            product.Description = data.Description;
            product.Price = data.Price;
            
            await _db.SaveChangesAsync(cancellationToken);
            
            return _mapper.Map<ProductDto>(product);
        }

        public async Task DeleteProduct(int id, CancellationToken cancellationToken)
        {
            var product = await _db.Products
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync(cancellationToken);
            
            if (product == null)
            {
                throw new Exception();
            }
            
            _db.Products.Remove(product);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}