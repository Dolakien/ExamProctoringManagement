using ExamProctoringManagement.Contract.Payloads.Request.UsersRequest;
using FluentValidation;
using System.Text.RegularExpressions;

namespace ExamProctoringManagement.API.Validations
{
    public class CreateUserRequestValidation : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidation()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User Id is Required")
                .Must(FeIdValidate).WithMessage("Valid UserId is Required");
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("User Name is Required")
                .MinimumLength(6).WithMessage("User Name must larger than 6 characters");
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is Required");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is Required")
                .Length(6, 20).WithMessage("Password must must be 6 characters and less than 20 characters");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is Required")
                .EmailAddress().WithMessage("Valid Email is Required");
            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Gender is Required");
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone is required")
                .Must(PhoneValidate).WithMessage("Phone must not contain any character")
                .Length(10, 11).WithMessage("Phone must be 10 to 11 numbers");

            RuleFor(x => x.Dob)
                .Must(DobValidate).WithMessage("Date of birth is invalid");
        }

        private bool PhoneValidate(string phone)
        {
            var pattern = @"^\d+$";
            return Regex.IsMatch(phone, pattern) ? true : false;
        }

        private bool FeIdValidate(string feId)
        {
            string regex = @"^[SQDCH][A-Z]\d{6}$";
            return Regex.IsMatch(feId, regex) ? true : false;
        }

        private bool DobValidate(DateTime? Dob)
        {
            if (Dob == null) return true;
            int age = DateTime.UtcNow.Year - Dob.Value.Year;
            return (age >= 18) ? true : false;
        }
    }
}
