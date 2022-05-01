using AutoMapper;
using WebShopApi.Controllers.Client.Requests;
using WebShopApi.Controllers.Order.Requests;
using WebShopApi.Controllers.Product.Requests;
using WebShopDomain.Entities;
using WebShopDomain.Models;

namespace WebShopApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateClientRequest, ClientDto>();
            CreateMap<UpdateClientRequest, ClientDto>();
            CreateMap<Client, ClientDto>();
            
            CreateMap<CreateProductRequest, ProductDto>();
            CreateMap<UpdateProductRequest, ProductDto>();
            CreateMap<Product, ProductDto>();
            
            CreateMap<CreateOrderRequest, OrderDto>();
            CreateMap<UpdateOrderRequest, OrderDto>();
            CreateMap<Order, OrderDto>();
        }
    }
}