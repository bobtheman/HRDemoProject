namespace HRDemo.Api.EmployeDataValidator
{
    using FluentValidation;
    using HRDemo.Api.Features.EmployeeData.CreateEmployeeData;
    using HRDemo.Api.Features.EmployeeData.DeleteEomployeeData;
    using HRDemo.Api.Features.EmployeeData.UpdateEmployeeData;

    public static class EmployeeDataValidationRules
    {
        public static void CreateEmployeeDataValidationRules(this AbstractValidator<CreateEmployeeData.Command> validator)
        {
            validator.RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName is required");
            validator.RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName is required");
            validator.RuleFor(x => x.EmailAddress).NotEmpty().EmailAddress().WithMessage("Valid Email Address Required");
            validator.RuleFor(x => x.DateOfBirth).NotEmpty().Must(date => date != default(DateTime)).WithMessage("Date of Birth must be a valid date.");
            validator.RuleFor(x => x.DepartmentId).NotEmpty().GreaterThan(0).WithMessage("DepartmentId is required and must be a valid value");
            validator.RuleFor(x => x.EmployeeStatusId).NotEmpty().GreaterThan(0).WithMessage("EmployeeStatusId is required and must be a valid value");
            validator.RuleFor(x => x.EmployeeNumber).NotEmpty().WithMessage("EmployeeNumber is required");
            validator.RuleFor(x => x.FirstName).MaximumLength(50).WithMessage("FirstName cannot exceed 100 characters");
            validator.RuleFor(x => x.LastName).MaximumLength(50).WithMessage("LastName cannot exceed 100 characters");
            validator.RuleFor(x => x.EmployeeNumber).Matches(@"^[A-Z0-9]+$").WithMessage("EmployeeNumber must be alphanumeric");
        }

        public static void UpdateEmployeeDataValidationRules(this AbstractValidator<UpdateEmployeeData.Command> validator)
        {
            validator.RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            validator.RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName is required");
            validator.RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName is required");
            validator.RuleFor(x => x.EmailAddress).NotEmpty().EmailAddress().WithMessage("Valid Email Address Required");
            validator.RuleFor(x => x.DateOfBirth).NotEmpty().Must(date => date != default(DateTime)).WithMessage("Date of Birth must be a valid date.");
            validator.RuleFor(x => x.DepartmentId).NotEmpty().GreaterThan(0).WithMessage("DepartmentId is required and must be a valid value");
            validator.RuleFor(x => x.EmployeeStatusId).NotEmpty().GreaterThan(0).WithMessage("EmployeeStatusId is required and must be a valid value");
            validator.RuleFor(x => x.EmployeeNumber).NotEmpty().WithMessage("EmployeeNumber is required");
            validator.RuleFor(x => x.FirstName).MaximumLength(50).WithMessage("FirstName cannot exceed 100 characters");
            validator.RuleFor(x => x.LastName).MaximumLength(50).WithMessage("LastName cannot exceed 100 characters");
            validator.RuleFor(x => x.EmployeeNumber).Matches(@"^[A-Z0-9]+$").WithMessage("EmployeeNumber must be alphanumeric");
        }

        public static void DeleteEmployeeDataValidationRules(this AbstractValidator<DeleteEmployeeData.Command> validator)
        {
            validator.RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
