using AutoMapper;
using WebShopApi.Controllers.Client.Requests;
using WebShopApi.Controllers.Client.Responses;
using WebShopApi.Controllers.Product.Requests;
using WebShopApi.Controllers.Product.Responses;
using WebShopDomain.Entities;
using WebShopDomain.Models;

namespace WebShopApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClientDto, ClientResponse>();
            CreateMap<CreateClientRequest, ClientDto>();
            CreateMap<UpdateClientRequest, ClientDto>();
            CreateMap<Client, ClientDto>();

            CreateMap<ProductDto, ProductResponse>();
            CreateMap<CreateProductRequest, ProductDto>();
            CreateMap<UpdateProductRequest, ProductDto>();
            CreateMap<Product, ProductDto>();
        }
    }
}