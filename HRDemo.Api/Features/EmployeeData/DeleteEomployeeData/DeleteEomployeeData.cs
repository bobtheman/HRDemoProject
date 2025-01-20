using Carter;
using FluentValidation;
using HRDemo.Api.Contracts.EmployeeData;
using HRDemo.Api.Database;
using HRDemo.Api.Shared;
using HRDemo.Api.Validator.EmployeDataValidator;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRDemo.Api.Features.EmployeeData.DeleteEomployeeData
{
    public static class DeleteEmployeeData
    {
        public class Command : IRequest<Result<int>>
        {
            public int Id { get; set; } = default!;
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                EmployeeDataValidationRules.DeleteEmployeeDataValidationRules(this);
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

            public async Task<Result<int>> Handle(DeleteEmployeeData.Command request, CancellationToken cancellationToken)
            {
                var validationResult = _validator.Validate(request);

                if (!validationResult.IsValid)
                {
                    return Result.Failure<int>(new Error("DeleteEmployeeData.Validation", validationResult.ToString()));
                }

                var employeeData = await _dbContext.EmployeeData.FindAsync(request.Id);

                if (employeeData == null)
                {
                    return Result.Failure<int>(new Error("DeleteEmployeeData.NotFound", $"EmployeeData not found with Id: {request.Id}"));
                }

                _dbContext.EmployeeData.Remove(employeeData);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return 0;
            }
        }
    }

    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/api/Employee/DeleteEmployeeData", async ([FromBody] DeleteEmployeeDataRequest request, [FromServices] ISender sender) =>
            {
                var command = request.Adapt<DeleteEmployeeData.Command>();

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