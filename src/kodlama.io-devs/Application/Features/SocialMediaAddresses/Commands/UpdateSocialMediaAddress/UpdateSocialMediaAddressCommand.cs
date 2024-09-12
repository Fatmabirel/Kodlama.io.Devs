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

namespace Application.Features.SocialMediaAddresses.Commands.UpdateSocialMediaAddress
{
    public class UpdateSocialMediaAddressCommand : IRequest<UpdatedSocialMediaAddressDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? GithubUrl { get; set; }
        public string? LinkedinUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? MediumUrl { get; set; }
        public class UpdateSocialMediaAddressCommandHandler : IRequestHandler<UpdateSocialMediaAddressCommand, UpdatedSocialMediaAddressDto>
        {
            private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;
            private readonly IMapper _mapper;

            public UpdateSocialMediaAddressCommandHandler(ISocialMediaAddressRepository socialMediaAddressRepository, IMapper mapper)
            {
                _socialMediaAddressRepository = socialMediaAddressRepository;
                _mapper = mapper;
            }
            public async Task<UpdatedSocialMediaAddressDto> Handle(UpdateSocialMediaAddressCommand request, CancellationToken cancellationToken)
            {
                SocialMediaAddress socialMediaAddress = _mapper.Map<SocialMediaAddress>(request);
                SocialMediaAddress updatedSocialMediaAddress = await _socialMediaAddressRepository.UpdateAsync(socialMediaAddress);
                UpdatedSocialMediaAddressDto updatedSocialMediaAddressDto = _mapper.Map<UpdatedSocialMediaAddressDto>(updatedSocialMediaAddress);
                return updatedSocialMediaAddressDto;
            }
        }
    }
}
