using Application.Features.SocialMediaAddresses.Commands.CreateSocialMediaAddress;
using Application.Features.SocialMediaAddresses.Commands.DeleteSocialMediaAddress;
using Application.Features.SocialMediaAddresses.Commands.UpdateSocialMediaAddress;
using Application.Features.SocialMediaAddresses.Dtos;
using Application.Features.SocialMediaAddresses.Models;
using Application.Features.SocialMediaAddresses.Queries.GetByIdSocialMediaAddress;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.SocialMediaAddresses.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SocialMediaAddress, CreatedSocialMediaAddressDto>().ReverseMap();
            CreateMap<SocialMediaAddress, CreateSocialMediaAddressCommand>().ReverseMap();

            CreateMap<SocialMediaAddress, UpdatedSocialMediaAddressDto>().ReverseMap();
            CreateMap<SocialMediaAddress, UpdateSocialMediaAddressCommand>().ReverseMap();

            CreateMap<SocialMediaAddress, DeletedSocialMediaAddressDto>().ReverseMap();
            CreateMap<SocialMediaAddress, DeleteSocialMediaAddressCommand>().ReverseMap();

            CreateMap<IPaginate<SocialMediaAddress>, SocialMediaAddressListModel>().ReverseMap();
            CreateMap<SocialMediaAddress, SocialMediaAddressListDto>().
                    ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User.FirstName)).
                    ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.User.LastName)).
                ReverseMap();

            CreateMap<SocialMediaAddress, SocialMediaAddressGetByIdDto>().
                 ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User.FirstName)).
                    ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.User.LastName)).
                    ReverseMap();
            CreateMap<SocialMediaAddress, GetByIdSocialMediaAddressQuery>().ReverseMap();
        }
    }
}
