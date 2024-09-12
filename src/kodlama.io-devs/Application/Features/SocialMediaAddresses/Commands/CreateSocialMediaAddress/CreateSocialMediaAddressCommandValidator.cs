using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMediaAddresses.Commands.CreateSocialMediaAddress
{
    public class CreateSocialMediaAddressCommandValidator : AbstractValidator<CreateSocialMediaAddressCommand> // create komutunda validasyon kodlarını çalıştır
    {
        public CreateSocialMediaAddressCommandValidator()
        {
            RuleFor(t => t.UserId).NotEmpty();
        }
    }
}
