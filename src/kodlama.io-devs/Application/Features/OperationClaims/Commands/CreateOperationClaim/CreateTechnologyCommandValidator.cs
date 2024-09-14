using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using FluentValidation;

namespace Application.Features.Technologies.Commands.CreateOperationClaim
{
    public class CreateTechnologyCommandValidator : AbstractValidator<CreateOperationClaimCommand> // create komutunda validasyon kodlarını çalıştır
    {
        public CreateTechnologyCommandValidator()
        {
            RuleFor(t => t.Name).NotEmpty().MinimumLength(2).MaximumLength(20);
        }
    }
}
