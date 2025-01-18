using Carter;
using HRDemo.Api.Contracts.Department;
using HRDemo.Api.Contracts.EmployeeData;
using HRDemo.Api.Contracts.EmployeeStatus;
using HRDemo.Api.Database;
using HRDemo.Api.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRDemo.Api.Features.EmployeeData
{
    public class GetAllEmployeeData
    {
        public class GetAllEmployees : IRequest<Result<List<EmployeeDataResponse>>>
        {
        }

        internal sealed class Handler : IRequestHandler<GetAllEmployees, Result<List<EmployeeDataResponse>>>
        {
            private readonly AppDbContext _dbContext;

            public Handler(AppDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Result<List<EmployeeDataResponse>>> Handle(GetAllEmployees request, CancellationToken cancellationToken)
            {
                var employeeDataResponses = await _dbContext
                    .EmployeeData
                    .AsNoTracking()
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
                    .ToListAsync(cancellationToken);

                return Result.Success(employeeDataResponses);
            }
        }

        public class GetAllEmployeeDataQuery : ICarterModule
        {
            public void AddRoutes(IEndpointRouteBuilder app)
            {
                app.MapGet("/api/getallemployees", async (ISender sender) =>
                {
                    var query = new GetAllEmployeeData.GetAllEmployees();

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
}
