namespace HRDemo.Api.Tests.Features.Department
{
    using FluentValidation;
    using HRDemo.Api.Database;
    using HRDemo.Api.Entities;
    using HRDemo.Api.Features.Department.GetDepartmentData;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Moq.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class DepartmentTests
    {
        private readonly Mock<AppDbContext> _dbContextMock;
        private readonly Mock<IValidator<GetFilteredDepartmentData.GetFilteredDepartment>> _validatorMock;
        private readonly GetFilteredDepartmentData.Handler _handler;

        public DepartmentTests()
        {
            _dbContextMock = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            _dbContextMock = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            _dbContextMock.Setup(db => db.Departments).ReturnsDbSet(GetMockDepartmentList());
            _handler = new GetFilteredDepartmentData.Handler(_dbContextMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnSuccessResult_WhenDepartmentsExist()
        {
            // Arrange
            var request = new GetFilteredDepartmentData.GetFilteredDepartment { Name = "HR" };

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Single(result.Value);
            Assert.Equal("HR", result.Value[0].Name);
        }

        private List<Department> GetMockDepartmentList()
        {
            return new List<Department>
            {
                new Department
                {
                    Id = 1,
                    Name = "IT"
                },
                new Department
                {
                    Id = 2,
                    Name = "Sales"
                },
                new Department
                {
                    Id = 3,
                    Name = "Accounts"
                },
                new Department
                {
                    Id = 4,
                    Name = "HR"
                },
                new Department
                {
                    Id = 5,
                    Name = "Admin"
                }
            };
        }
    }
}
