using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommandValidator : AbstractValidator<CreateTechnologyCommand> // create komutunda validasyon kodlarını çalıştır
    {
        public CreateTechnologyCommandValidator()
        {
            RuleFor(t=>t.ProgrammingLanguageId).NotEmpty();
            RuleFor(t=>t.Name).NotEmpty().MinimumLength(2).MaximumLength(20);
        }
    }
}
