using Application.Features.ProgrammingLanguages.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameMustBeUnique(string name)
        {
            ProgrammingLanguage programmingLanguage = await _programmingLanguageRepository.GetAsync(p=>p.Name == name);
            if (programmingLanguage != null)
                throw new BusinessException(Messages.ProgrammingLanguageNameMustBeUnique);
        }
    }
}
