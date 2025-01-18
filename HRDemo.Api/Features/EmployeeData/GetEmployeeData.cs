using Carter;
using HRDemo.Api.Contracts.Department;
using HRDemo.Api.Contracts.EmployeeData;
using HRDemo.Api.Contracts.EmployeeStatus;
using HRDemo.Api.Database;
using HRDemo.Api.Features.EmployeeData;
using HRDemo.Api.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRDemo.Api.Features.EmployeeData
{
    public static class GetEmployeeData
    {
        public class GetEmployeesByEmployeeId : IRequest<Result<EmployeeDataResponse>>
        {
            public int Id { get; set; }
        }


        internal sealed class Handler : IRequestHandler<GetEmployeesByEmployeeId, Result<EmployeeDataResponse>>
        {
            private readonly AppDbContext _dbContext;

            public Handler(AppDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Result<EmployeeDataResponse>> Handle(GetEmployeesByEmployeeId request, CancellationToken cancellationToken)
            {
                var employeeDataResponse = await _dbContext
                    .EmployeeData
                    .AsNoTracking()
                    .Where(employeeData => employeeData.Id == request.Id)
                    .Select(employeeData => new EmployeeDataResponse
                    {
                        Id = employeeData.Id,
                        FirstName = employeeData.FirstName,
                        LastName = employeeData.LastName,
                        DateOfBirth = employeeData.DateOfBirth,
                        DepartmentId = employeeData.DepartmentId,
                        EmployeeStatusId = employeeData.EmployeeStatusId,
                        EmployeeNumber = employeeData.EmployeeNumber,
                        Department = new DepartmentResponse
                        {
                            Id = employeeData.Department.Id,
                            Name = employeeData.Department.Name,
                        },
                        EmployeeStatus = new EmployeeStatusResponse
                        {
                            Id = employeeData.EmployeeStatus.Id,
                            Name = employeeData.EmployeeStatus.Name
                        }
                    })
                    .FirstOrDefaultAsync(cancellationToken);

                if (employeeDataResponse is null)
                {
                    return Result.Failure<EmployeeDataResponse>(new Error(
                        "EmployeeData.Null",
                        "EmployeeData ID was not found"));
                }

                return employeeDataResponse;
            }

            
        }
    }

    public class GetEmployeeDataQuery: ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/getemployee/{id}", async (int id, ISender sender) =>
            {
                var query = new GetEmployeeData.GetEmployeesByEmployeeId { Id = id };

                var result = await sender.Send(query);

                if (result.IsFailure)
                {
                    return Results.NotFound(result.Error);
                }

                return Results.Ok(result.Value);
            });
        }
    }
}
