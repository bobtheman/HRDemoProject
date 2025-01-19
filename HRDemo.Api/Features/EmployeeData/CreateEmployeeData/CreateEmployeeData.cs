using Carter;
using FluentValidation;
using HRDemo.Api.Database;
using MediatR;
using HRDemo.Api.Shared;
using Mapster;
using HRDemo.Api.Contracts.EmployeeData;

namespace HRDemo.Api.Features.EmployeeData.CreateEmployeeData
{
    public static class CreateEmployeeData
    {
        public class Command : IRequest<Result<int>>
        {
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public DateTime DateOfBirth { get; set; } = default!;
            public int DepartmentId { get; set; } = default!;
            public int EmployeeStatusId { get; set; } = default!;
            public string EmployeeNumber { get; set; } = string.Empty;
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.FirstName).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
                RuleFor(x => x.DateOfBirth).NotEmpty();
                RuleFor(x => x.DepartmentId).NotEmpty();
                RuleFor(x => x.EmployeeStatusId).NotEmpty();
                RuleFor(x => x.EmployeeNumber).NotEmpty();
            }
        }

        internal sealed class Handler : IRequestHandler<Command, Result<int>>
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
                    return Result.Failure<int>(new Error("CreateEmployeeData.Validation", validationResult.ToString()));
                }

                var employeeData = new Entities.EmployeeData()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    DateOfBirth = request.DateOfBirth,
                    DepartmentId = request.DepartmentId,
                    EmployeeStatusId = request.EmployeeStatusId,
                    EmployeeNumber = request.EmployeeNumber
                };

                _dbContext.EmployeeData.Add(employeeData);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return employeeData.Id;
            }
        }
    }

    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/Employee/CreateEmployeedata", async (CreateEmployeeDataRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateEmployeeData.Command>();

                var result = await sender.Send(command);

                if (result.IsFailure)
                {
                    return Results.BadRequest(result.Error);
                }

                return Results.Ok(result.Value);
            });
        }
    }
}
