using Carter;
using HRDemo.Api.Contracts.EmployeeStatus;
using HRDemo.Api.Database;
using HRDemo.Api.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRDemo.Api.Features.EmployeeStatus.GetEmployeeStatus
{
    public static class GetFilteredEmployeeStatusData
    {
        public class GetFilteredEmployeeStatus : IRequest<Result<List<EmployeeStatusResponse>>>
        {
            public int Id { get; set; } = default;
            public string Name { get; set; } = string.Empty;
        }


        public class Handler : IRequestHandler<GetFilteredEmployeeStatus, Result<List<EmployeeStatusResponse>>>
        {
            private readonly AppDbContext _dbContext;

            public Handler(AppDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Result<List<EmployeeStatusResponse>>> Handle(GetFilteredEmployeeStatus request, CancellationToken cancellationToken)
            {
                var query = _dbContext.EmployeeStatus.AsNoTracking().AsQueryable();

                if (request.Id != 0)
                {
                    query = query.Where(employeeStatus => employeeStatus.Id == request.Id);
                }

                if (!string.IsNullOrEmpty(request.Name))
                {
                    query = query.Where(employeeStatus => employeeStatus.Name.Contains(request.Name));
                }


                var employeeStatusResponse = await query
                    .Select(employeeStatus => new EmployeeStatusResponse
                    {
                        Id = employeeStatus.Id,
                        Name = employeeStatus.Name
                    })
                    .ToListAsync(cancellationToken);

                if (employeeStatusResponse is null || !employeeStatusResponse.Any())
                {
                    return Result.Failure<List<EmployeeStatusResponse>>(new Error(
                        "EmployeeStatusList.Null",
                        "EmployeeStatusList result"));
                }

                return Result.Success(employeeStatusResponse);
            }
        }
    }

    public class GetFilteredEmployeeStatusDataQuery : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/EmployeeStatus/GetFilteredEmployeeStatuslist/", async (int? Id, string? Name, ISender sender) =>
            {
                var query = new GetFilteredEmployeeStatusData.GetFilteredEmployeeStatus
                {
                    Id = Id ?? default,
                    Name = Name ?? string.Empty
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
