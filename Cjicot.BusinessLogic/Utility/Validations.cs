using Cjicot.Presentation.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cjicot.Presentation.Utility
{
    public class RegistrationValidator: AbstractValidator<RegistrationDto>
    {
        public RegistrationValidator()
        {
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.Username).NotEmpty();
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.FullName).NotEmpty();
            RuleFor(p => p.MobileNumber).NotEmpty();
        }
    }
}
