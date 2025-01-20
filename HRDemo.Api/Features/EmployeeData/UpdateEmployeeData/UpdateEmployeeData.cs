namespace HRDemo.Api.Features.EmployeeData.UpdateEmployeeData
{
    using Carter;
    using FluentValidation;
    using HRDemo.Api.Database;
    using MediatR;
    using HRDemo.Api.Shared;
    using Mapster;
    using HRDemo.Api.Contracts.EmployeeData;
    using Microsoft.EntityFrameworkCore;
    using HRDemo.Api.Validator.EmployeDataValidator;

    public static class UpdateEmployeeData
    {
        public class Command : IRequest<Result<int>>
        {
            public int Id { get; set; } = default!;
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public string EmailAddress { get; set; } = string.Empty;
            public DateTime DateOfBirth { get; set; } = default!;
            public int DepartmentId { get; set; } = default!;
            public int EmployeeStatusId { get; set; } = default!;
            public string EmployeeNumber { get; set; } = string.Empty;
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                EmployeeDataValidationRules.UpdateEmployeeDataValidationRules(this);
            }
        }

        public class Handler : IRequestHandler<Command, Result<int>>
        {
            private readonly AppDbContext _dbContext;
            private readonly IValidator<Command> _validator;

            public Handler(AppDbContext dbContext, IValidator<Command> validator)
            {
                _dbContext = dbContext;
                _validator = validator;
            }

            public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
            {
                var validationResult = _validator.Validate(request);

                if (!validationResult.IsValid)
                {
                    return Result.Failure<int>(new Error("UpdateEmployeeData.Validation", validationResult.ToString()));
                }

                var emailExists = await _dbContext.EmployeeData.AnyAsync(e => e.EmailAddress == request.EmailAddress && e.Id != request.Id, cancellationToken);
                if (emailExists)
                {
                    return Result.Failure<int>(new Error("UpdateEmployeeData.DuplicateEmail", "The email address is already in use"));
                }

                var employeeStatusList = _dbContext.EmployeeStatus.AsNoTracking().AsQueryable();

                var approvedStatus = await employeeStatusList.FirstOrDefaultAsync(es => es.Name == "Approved", cancellationToken);
                
                if (request.EmployeeStatusId == approvedStatus?.Id)
                {
                    var employeeNumberAlreadyExists = await _dbContext.EmployeeData.AnyAsync(e => e.EmployeeNumber == request.EmployeeNumber && e.Id != request.Id, cancellationToken);
                    if (employeeNumberAlreadyExists)
                    {
                        return Result.Failure<int>(new Error("UpdateEmployeeData.DuplicateEmployeeNumber", "An approved employee with that employee number already exists"));
                    }
                }

                var employeeData = new Entities.EmployeeData()
                {
                    Id = request.Id,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    EmailAddress = request.EmailAddress,
                    DateOfBirth = request.DateOfBirth,
                    DepartmentId = request.DepartmentId,
                    EmployeeStatusId = request.EmployeeStatusId,
                    EmployeeNumber = request.EmployeeNumber
                };

                _dbContext.EmployeeData.Update(employeeData);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return Result.Success(employeeData.Id);
            }
        }
    }

    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/api/Employee/UpdateEmployeeData", async (UpdateEmployeeDataRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateEmployeeData.Command>();

                var result = await sender.Send(command);

                if (result.IsFailure)
                {
                    return Results.BadRequest(result.Error);
                }

                return Results.Ok(result);
            });
        }
    }
}
