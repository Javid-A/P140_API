using FluentValidation;
using P140_API.DTOs;

namespace P140_API.Validators
{
    public class CreateStudentAttendanceDTOValidator:AbstractValidator<CreateStudentAttendanceDTO>
    {
        public CreateStudentAttendanceDTOValidator()
        {
            //RuleFor(sa=>sa.GroupId).GreaterThan() - >
            //RuleFor(sa => sa.GroupId).GreaterThanOrEqualTo() - >=
            //RuleFor(sa => sa.Attendance).GreaterThanOrEqualTo(1).WithMessage("1-den boyuk")
            //    .LessThanOrEqualTo(3).WithMessage("3-den kicik");
            RuleFor(sa => sa.Attendance).Custom((attendance, context) =>
            {
                switch (attendance)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        context.AddFailure("Attendance", "1-3");
                        break;
                }
            });
        }
    }
}
