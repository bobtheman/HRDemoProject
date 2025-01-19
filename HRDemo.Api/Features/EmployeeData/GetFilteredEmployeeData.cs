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
    public static class GetFilteredEmployeeData
    {
        public class GetFilteredEmployee : IRequest<Result<List<EmployeeDataResponse>>>
        {
            public int Id { get; set; } = default;
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public DateTime DateOfBirth { get; set; } = default;
            public int DepartmentId { get; set; } = default;
            public int EmployeeStatusId { get; set; } = default;
        }


        internal sealed class Handler : IRequestHandler<GetFilteredEmployee, Result<List<EmployeeDataResponse>>>
        {
            private readonly AppDbContext _dbContext;

            public Handler(AppDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Result<List<EmployeeDataResponse>>> Handle(GetFilteredEmployee request, CancellationToken cancellationToken)
            {
                var query = _dbContext.EmployeeData.AsNoTracking().AsQueryable();

                if (request.Id != 0)
                {
                    query = query.Where(employeeData => employeeData.Id == request.Id);
                }

                if (!string.IsNullOrEmpty(request.FirstName))
                {
                    query = query.Where(employeeData => employeeData.FirstName.Contains(request.FirstName));
                }

                if (!string.IsNullOrEmpty(request.LastName))
                {
                    query = query.Where(employeeData => employeeData.LastName.Contains(request.LastName));
                }

                if (request.DateOfBirth != DateTime.MinValue)
                {
                    query = query.Where(employeeData => employeeData.DateOfBirth == request.DateOfBirth);
                }

                if (request.DepartmentId != 0)
                {
                    query = query.Where(employeeData => employeeData.DepartmentId == request.DepartmentId);
                }

                if (request.EmployeeStatusId != 0)
                {
                    query = query.Where(employeeData => employeeData.EmployeeStatusId == request.EmployeeStatusId);
                }

                var employeeDataResponse = await query
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
                            Name = employeeData.Department.Name
                        },
                        EmployeeStatus = new EmployeeStatusResponse
                        {
                            Id = employeeData.EmployeeStatus.Id,
                            Name = employeeData.EmployeeStatus.Name
                        }
                    })
                    .ToListAsync(cancellationToken);

                if (employeeDataResponse is null || !employeeDataResponse.Any())
                {
                    return Result.Failure<List<EmployeeDataResponse>>(new Error(
                        "EmployeeDataList.Null",
                        "EmployeeDataList result"));
                }

                return Result.Success(employeeDataResponse);
            }
        }
    }

    public class GetFilteredEmployeeDataQuery : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/Employee/GetFilteredEmployeelist/", async (int? Id, string? firstname, string? lastname, DateTime? dateofbirth, int? departmentid, int? employeestatusid, ISender sender) =>
            {
                var query = new GetFilteredEmployeeData.GetFilteredEmployee
                {
                    Id = Id ?? default,
                    FirstName = firstname ?? string.Empty,
                    LastName = lastname ?? string.Empty,
                    DateOfBirth = dateofbirth ?? default,
                    DepartmentId = departmentid ?? default,
                    EmployeeStatusId = employeestatusid ?? default
                };

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
