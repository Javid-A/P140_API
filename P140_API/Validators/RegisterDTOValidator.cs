using FluentValidation;
using P140_API.DTOs;

namespace P140_API.Validators
{
    public class RegisterDTOValidator:AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator()
        {
            RuleFor(r => r.Email).EmailAddress().WithMessage("Email is incorrect");
            //RuleFor(r => r.Password).Equal(r => r.ConfirmPassword).WithMessage("Confirm and password does not match");
            RuleFor(r => r).Custom((a, context) =>
            {
                if (a.Password !=a.ConfirmPassword)
                {
                    context.AddFailure("Passwords", "Passwords does not match");
                }
            });
        }
    }
}
