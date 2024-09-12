using Application.Features.SocialMediaAddresses.Dtos;
using Application.Features.Technologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SocialMediaAddresses.Queries.GetByIdSocialMediaAddress
{
    public class GetByIdSocialMediaAddressQuery : IRequest<SocialMediaAddressGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdSocialMediaAddressQueryHandler : IRequestHandler<GetByIdSocialMediaAddressQuery, SocialMediaAddressGetByIdDto>
        {
            private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;
            private readonly IMapper _mapper;

            public GetByIdSocialMediaAddressQueryHandler(ISocialMediaAddressRepository socialMediaAddressRepository, IMapper mapper)
            {
                _socialMediaAddressRepository = socialMediaAddressRepository;
                _mapper = mapper;
            }

            public async Task<SocialMediaAddressGetByIdDto> Handle(GetByIdSocialMediaAddressQuery request, CancellationToken cancellationToken)
            {
                SocialMediaAddress? socialMediaAddress = await _socialMediaAddressRepository.Query()
                     .Include(t => t.User)
                     .FirstOrDefaultAsync(t => t.Id == request.Id);

                SocialMediaAddressGetByIdDto socialMediaAddressGetByIdDto = _mapper.Map<SocialMediaAddressGetByIdDto>(socialMediaAddress);
                return socialMediaAddressGetByIdDto;
            }
        }
    }
}
