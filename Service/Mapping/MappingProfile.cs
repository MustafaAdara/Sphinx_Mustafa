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

            CreateMap<ClientProduct, ClientProductDto>().ReverseMap();
            CreateMap<ClientProduct, ClientProductDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

        }

    }
}
