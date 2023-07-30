using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AuthValidator : AbstractValidator<UserForRegisterDto>
    {
        public AuthValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();

        }

        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}
