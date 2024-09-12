using Application.Features.SocialMediaAddresses.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SocialMediaAddresses.Queries.GetListSocialMediaAddress
{
    
    public class GetListSocialMediaAddressQuery : IRequest<SocialMediaAddressListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListSocialMediaAddressQueryHandler : IRequestHandler<GetListSocialMediaAddressQuery, SocialMediaAddressListModel>
        {
            private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;
            private readonly IMapper _mapper;

            public GetListSocialMediaAddressQueryHandler(ISocialMediaAddressRepository SocialMediaAddressRepository, IMapper mapper)
            {
                _socialMediaAddressRepository = SocialMediaAddressRepository;
                _mapper = mapper;
            }

            public async Task<SocialMediaAddressListModel> Handle(GetListSocialMediaAddressQuery request, CancellationToken cancellationToken)
            {
                IPaginate<SocialMediaAddress> socialMediaAddress = await _socialMediaAddressRepository.GetListAsync(include:
                     t => t.Include(p => p.User),
                     index: request.PageRequest.Page,
                     size: request.PageRequest.PageSize);
                SocialMediaAddressListModel mappedSocialMediaAddress = _mapper.Map<SocialMediaAddressListModel>(socialMediaAddress);
                return mappedSocialMediaAddress;

            }
        }
    }
}
