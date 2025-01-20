namespace HRDemo.Api.Tests.Features.EmployeeData
{
    using FluentValidation;
    using HRDemo.Api.Database;
    using HRDemo.Api.Entities;
    using HRDemo.Api.Features.EmployeeData.DeleteEomployeeData;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class DeleteEmployeeDataTests
    {
        private readonly Mock<AppDbContext> _dbContextMock;
        private readonly Mock<IValidator<DeleteEmployeeData.Command>> _validatorMock;
        private readonly DeleteEmployeeData.Handler _handler;

        public DeleteEmployeeDataTests()
        {
            _dbContextMock = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            _validatorMock = new Mock<IValidator<DeleteEmployeeData.Command>>();
            _handler = new DeleteEmployeeData.Handler(_dbContextMock.Object, _validatorMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailure_WhenValidationFails()
        {
            // Arrange
            var command = new DeleteEmployeeData.Command { Id = 1 };
            var validationResult = new FluentValidation.Results.ValidationResult(new[] { new FluentValidation.Results.ValidationFailure("Id", "Invalid Id") });
            _validatorMock.Setup(v => v.Validate(command)).Returns(validationResult);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal("DeleteEmployeeData.Validation", result.Error.Code);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailure_WhenEmployeeDataNotFound()
        {
            // Arrange
            var command = new DeleteEmployeeData.Command { Id = 1 };
            _validatorMock.Setup(v => v.Validate(command)).Returns(new FluentValidation.Results.ValidationResult());
            _dbContextMock.Setup(db => db.EmployeeData.FindAsync(command.Id)).ReturnsAsync((EmployeeData)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal("DeleteEmployeeData.NotFound", result.Error.Code);
        }

        [Fact]
        public async Task Handle_ShouldReturnSuccess_WhenEmployeeDataDeleted()
        {
            // Arrange
            var command = new DeleteEmployeeData.Command { Id = 1 };
            var employeeData = new EmployeeData { Id = 1 };
            _validatorMock.Setup(v => v.Validate(command)).Returns(new FluentValidation.Results.ValidationResult());
            _dbContextMock.Setup(db => db.EmployeeData.FindAsync(command.Id)).ReturnsAsync(employeeData);
            _dbContextMock.Setup(db => db.EmployeeData.Remove(employeeData));
            _dbContextMock.Setup(db => db.SaveChangesAsync(CancellationToken.None)).ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(0, result.Value);
        }
    }
}
