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

namespace Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommand : IRequest<CreatedTechnologyDto>
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

        public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;

            public CreateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
            }

            public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology technology = _mapper.Map<Technology>(request); // gelen isteği maple ve teknolojiye dönüştür
                Technology createdTechnology = await _technologyRepository.AddAsync(technology); // veritabanına ekle
                CreatedTechnologyDto createdTechnologyDto = _mapper.Map<CreatedTechnologyDto>(createdTechnology); // dto'ya dönüştür
                return createdTechnologyDto;

            }
        }
    }
}
