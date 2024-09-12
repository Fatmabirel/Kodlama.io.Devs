using Application.Features.Technologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Queries.GetByIdTechnology
{
    public class GetByIdTechnologyQuery : IRequest<TechnologyGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdTechnologyQueryHandler : IRequestHandler<GetByIdTechnologyQuery, TechnologyGetByIdDto>
        {
            private readonly ITechnologyRepository _TechnologyRepository;
            private readonly IMapper _mapper;

            public GetByIdTechnologyQueryHandler(ITechnologyRepository TechnologyRepository, IMapper mapper)
            {
                _TechnologyRepository = TechnologyRepository;
                _mapper = mapper;
            }

            public async Task<TechnologyGetByIdDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
            {
                Technology? technology = await _TechnologyRepository.Query()
                     .Include(t => t.ProgrammingLanguage) 
                     .FirstOrDefaultAsync(t => t.Id == request.Id); 

                TechnologyGetByIdDto TechnologyGetByIdDto = _mapper.Map<TechnologyGetByIdDto>(technology);
                return TechnologyGetByIdDto;
            }
        }
    }
}
