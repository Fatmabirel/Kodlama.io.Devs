using Application.Features.SocialMediaAddresses.Dtos;
using Application.Features.Technologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMediaAddresses.Commands.CreateSocialMediaAddress
{
    public class CreateSocialMediaAddressCommand : IRequest<CreatedSocialMediaAddressDto>
    {
        public int UserId { get; set; }
        public string? GithubUrl { get; set; }
        public string? LinkedinUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? MediumUrl { get; set; }

        public class CreateSocialMediaAddressCommandHandler : IRequestHandler<CreateSocialMediaAddressCommand, CreatedSocialMediaAddressDto>
        {
            private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;
            private readonly IMapper _mapper;

            public CreateSocialMediaAddressCommandHandler(ISocialMediaAddressRepository socialMediaAddressRepository, IMapper mapper)
            {
                _socialMediaAddressRepository = socialMediaAddressRepository;
                _mapper = mapper;
            }

            public async Task<CreatedSocialMediaAddressDto> Handle(CreateSocialMediaAddressCommand request, CancellationToken cancellationToken)
            {
                SocialMediaAddress socialMediaAddress = _mapper.Map<SocialMediaAddress>(request); 
                SocialMediaAddress createdSocialMediaAddress = await _socialMediaAddressRepository.AddAsync(socialMediaAddress); 
                CreatedSocialMediaAddressDto createdSocialMediaAddressDto = _mapper.Map<CreatedSocialMediaAddressDto>(createdSocialMediaAddress); 
                return createdSocialMediaAddressDto;
            }
        }
    }
}
