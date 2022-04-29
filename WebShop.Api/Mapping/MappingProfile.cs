using AutoMapper;
using WebShopApi.Controllers.Client.Requests;
using WebShopApi.Controllers.Client.Responses;
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
        }
    }
}