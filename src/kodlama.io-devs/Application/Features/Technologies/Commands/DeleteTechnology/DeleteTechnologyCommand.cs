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

namespace Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand : IRequest<DeletedTechnologyDto>
    {
        public int Id { get; set; }
        public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
        {
            private readonly ITechnologyRepository _TechnologyRepository;
            private readonly IMapper _mapper;

            public DeleteTechnologyCommandHandler(ITechnologyRepository TechnologyRepository, IMapper mapper)
            {
                _TechnologyRepository = TechnologyRepository;
                _mapper = mapper;
            }
            public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology Technology = _mapper.Map<Technology>(request); //map request
                Technology deletedTechnology = await _TechnologyRepository.DeleteAsync(Technology); // delete MAPPED "Technology"
                DeletedTechnologyDto deletedTechnologyDto = _mapper.Map<DeletedTechnologyDto>(deletedTechnology);
                return deletedTechnologyDto;
            }
        }
    }
}
