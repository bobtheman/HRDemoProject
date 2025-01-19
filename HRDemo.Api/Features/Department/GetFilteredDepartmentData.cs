using Carter;
using HRDemo.Api.Contracts.Department;
using HRDemo.Api.Database;
using HRDemo.Api.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRDemo.Api.Features.Department
{
    public static class GetFilteredDepartmentData
    {
        public class GetFilteredDepartment : IRequest<Result<List<DepartmentResponse>>>
        {
            public int Id { get; set; } = default;
            public string Name { get; set; } = string.Empty;
            public bool Active { get; set; } = true;
        }


        internal sealed class Handler : IRequestHandler<GetFilteredDepartment, Result<List<DepartmentResponse>>>
        {
            private readonly AppDbContext _dbContext;

            public Handler(AppDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Result<List<DepartmentResponse>>> Handle(GetFilteredDepartment request, CancellationToken cancellationToken)
            {
                var query = _dbContext.Departments.AsNoTracking().AsQueryable();

                if (request.Id != 0)
                {
                    query = query.Where(department => department.Id == request.Id);
                }

                if (!string.IsNullOrEmpty(request.Name))
                {
                    query = query.Where(department => department.Name.Contains(request.Name));
                }

                var departmentResponse = await query
                    .Select(department => new DepartmentResponse
                    {
                        Id = department.Id,
                        Name = department.Name
                    })
                    .ToListAsync(cancellationToken);

                if (departmentResponse is null || !departmentResponse.Any())
                {
                    return Result.Failure<List<DepartmentResponse>>(new Error(
                        "DepartmentList.Null",
                        "DepartmentList result"));
                }

                return Result.Success(departmentResponse);
            }
        }
    }

    public class GetFilteredDepartmentDataQuery : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/Department/GetFilteredDepartmentlist/", async (int? Id, string? Name, ISender sender) =>
            {
                var query = new GetFilteredDepartmentData.GetFilteredDepartment
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
