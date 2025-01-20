namespace HRDemo.Api.Tests.Features.EmployeeStatus
{
    using FluentValidation;
    using HRDemo.Api.Database;
    using HRDemo.Api.Entities;
    using HRDemo.Api.Features.EmployeeStatus.GetEmployeeStatus;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Moq.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class EmployeeStatusTests
    {
        private readonly Mock<AppDbContext> _dbContextMock;
        private readonly Mock<IValidator<GetFilteredEmployeeStatusData.GetFilteredEmployeeStatus>> _validatorMock;
        private readonly GetFilteredEmployeeStatusData.Handler _handler;

        public EmployeeStatusTests()
        {
            _dbContextMock = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            _dbContextMock = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            _dbContextMock.Setup(db => db.EmployeeStatus).ReturnsDbSet(GetMockEmployeeStatusList());
            _handler = new GetFilteredEmployeeStatusData.Handler(_dbContextMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnSuccessResult_WhenEmployeeStatussExist()
        {
            // Arrange
            var request = new GetFilteredEmployeeStatusData.GetFilteredEmployeeStatus { Name = "Approved" };

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Single(result.Value);
            Assert.Equal("Approved", result.Value[0].Name);
        }

        private IEnumerable<EmployeeStatus> GetMockEmployeeStatusList()
        {
            return new List<EmployeeStatus>
            {
                new EmployeeStatus
                {
                    Id = 1,
                    Name = "Approved"
                },
                new EmployeeStatus
                {
                    Id = 2,
                    Name = "Pending"
                },
                new EmployeeStatus
                {
                    Id = 3,
                    Name = "Disabled"
                }
            };
        }
    }
}
