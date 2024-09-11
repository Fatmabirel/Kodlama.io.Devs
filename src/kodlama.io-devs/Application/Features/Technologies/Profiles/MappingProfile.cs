using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.DeleteTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using Application.Features.Technologies.Queries.GetByIdTechnology;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Technology, TechnologyListDto>()
                     .ForMember(dest => dest.ProgrammingLanguageName, opt => opt.MapFrom(src => src.ProgrammingLanguage.Name)).ReverseMap();

            CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();

            CreateMap<Technology, CreatedTechnologyDto>().ReverseMap();
            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();

            CreateMap<Technology, UpdatedTechnologyDto>().ReverseMap();
            CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();

            CreateMap<Technology, DeletedTechnologyDto>().ReverseMap();
            CreateMap<Technology, DeleteTechnologyCommand>().ReverseMap();

            CreateMap<Technology, TechnologyGetByIdDto>().ReverseMap();
            CreateMap<Technology, GetByIdTechnologyQuery>().ReverseMap();
        }
    }
}
