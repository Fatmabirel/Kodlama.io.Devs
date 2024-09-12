using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMediaAddresses.Commands.UpdateSocialMediaAddress
{
    public class UpdateSocialMediaAddressCommandValidator : AbstractValidator<UpdateSocialMediaAddressCommand>
    {
        public UpdateSocialMediaAddressCommandValidator()
        {
            RuleFor(t => t.UserId).NotEmpty();
        }
    }
}
