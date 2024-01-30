using FluentValidation;
using P140_API.DTOs;

namespace P140_API.Validators
{
    public class GroupCreateDTOValidator:AbstractValidator<GroupCreateDTO>
    {
        public GroupCreateDTOValidator()
        {
            RuleFor(g => g.Name).MinimumLength(3).WithMessage("minimum 3").NotEmpty().WithMessage("Not empty");
            RuleFor(g => g.Profession).MinimumLength(3).MaximumLength(15).NotEmpty().NotEqual("test");
        }
    }
}
