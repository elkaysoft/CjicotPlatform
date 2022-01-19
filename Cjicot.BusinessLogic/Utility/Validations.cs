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
            RuleFor(p => p.Country).NotEmpty();
            RuleFor(p => p.Gender).NotEmpty();
        }
    }

    public class LoginValidator: AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(p => p.Username).NotEmpty();
            RuleFor(p => p.Password).NotEmpty();
        }
    }

    public class JournalUploadValidator: AbstractValidator<UploadJournalsDto>
    {
        public JournalUploadValidator()
        {
            RuleFor(p => p.Keywords).NotEmpty();
            RuleFor(p => p.ProfileId).NotEmpty();
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.Abstract).NotEmpty();
            RuleFor(p => p.JournalType).NotEmpty();
            RuleFor(p => p.documents).NotNull();
            RuleFor(p => p.manuscriptAuthors).NotNull();
        }
    }
}
