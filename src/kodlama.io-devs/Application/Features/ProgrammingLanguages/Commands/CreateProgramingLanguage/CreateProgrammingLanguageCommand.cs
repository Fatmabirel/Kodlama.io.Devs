using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands
{
    public class CreateProgrammingLanguageCommand : IRequest<CreatedProgrammingLanguageDto> // using MediatR, call "createcommand" request, then returns dto
    {
        public string Name { get; set; } //while creating "something", id can't used. Because it is automatic increasement field. So just use "Name" property.

        public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreatedProgrammingLanguageDto> // with Handler method, we can run operations
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageBusinessRules.ProgrammingLanguageNameMustBeUnique(request.Name); //programming name must be unique
                ProgrammingLanguage programmingLanguage = _mapper.Map<ProgrammingLanguage>(request); // map request to convert it ProgrammingLanguage type
                ProgrammingLanguage createdProgrammingLanguage =  await _programmingLanguageRepository.AddAsync(programmingLanguage); // add MAPPED "programminglanguage"
                CreatedProgrammingLanguageDto createdProgrammingLanguageDto = _mapper.Map<CreatedProgrammingLanguageDto>(createdProgrammingLanguage); // map createdProgrammingLanguage to convert it Dto to show client
                return createdProgrammingLanguageDto;
            }
        }
    }
}
