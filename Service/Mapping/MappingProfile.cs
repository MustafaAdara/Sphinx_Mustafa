using Application.DTOs;
using AutoMapper;
using Domain.Entites;

namespace Application.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Client, ClientDto>().ReverseMap();

            CreateMap<ClientDetailsDto, Client>().ReverseMap();

            CreateMap<ClientProductDto, ClientProduct>().ReverseMap();
            CreateMap<ClientProduct, ClientProductDto>()
            .ForMember(dst => dst.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(c => c.ClientName, cp => cp.MapFrom(p => p.Client.Name));

        }

    }
}
