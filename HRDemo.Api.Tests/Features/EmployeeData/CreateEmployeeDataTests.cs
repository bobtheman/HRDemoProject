namespace HRDemo.Api.Tests.Features.EmployeeData
{
    using FluentValidation;
    using HRDemo.Api.Database;
    using HRDemo.Api.Entities;
    using HRDemo.Api.Features.EmployeeData.CreateEmployeeData;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using System;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;
    using FluentAssertions;
    using Moq.EntityFrameworkCore;

    public class CreateEmployeeDataTests
    {
        private readonly Mock<AppDbContext> _dbContextMock;
        private readonly Mock<IValidator<CreateEmployeeData.Command>> _validatorMock;
        private readonly CreateEmployeeData.Handler _handler;

        public CreateEmployeeDataTests()
        {
            _validatorMock = new Mock<IValidator<CreateEmployeeData.Command>>();
            _dbContextMock = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            _dbContextMock.Setup(db => db.EmployeeData).ReturnsDbSet(GetMockEmployeeData());
            _dbContextMock.Setup(db => db.EmployeeStatus).ReturnsDbSet(GetMockEmployeeStatusData());
            _handler = new CreateEmployeeData.Handler(_dbContextMock.Object, _validatorMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailure_WhenValidationFails()
        {
            // Arrange
            var command = new CreateEmployeeData.Command();
            var validationResult = new FluentValidation.Results.ValidationResult(new[] { new FluentValidation.Results.ValidationFailure("FirstName", "First name is required") });
            _validatorMock.Setup(v => v.Validate(command)).Returns(validationResult);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal("CreateEmployeeData.Validation", result.Error.Code);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailure_WhenEmailAlreadyExists()
        {
            // Arrange
            var command = new CreateEmployeeData.Command { EmailAddress = "john.doe@example.com" };
            _validatorMock.Setup(v => v.Validate(command)).Returns(new FluentValidation.Results.ValidationResult());
            _dbContextMock.Setup(db => db.EmployeeData).ReturnsDbSet(GetMockEmployeeData());

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal("CreateEmployeeData.DuplicateEmail", result.Error.Code);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailure_WhenEmailDoesntExists()
        {
            // Arrange
            var command = new CreateEmployeeData.Command { EmailAddress = "test@example.com" };
            _validatorMock.Setup(v => v.Validate(command)).Returns(new FluentValidation.Results.ValidationResult());
            _dbContextMock.Setup(db => db.EmployeeData).ReturnsDbSet(GetMockEmployeeData());

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
        }

        private List<EmployeeData> GetMockEmployeeData()
        {
            return new List<EmployeeData>
            {
                new EmployeeData
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    EmailAddress = "john.doe@example.com",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    DepartmentId = 1,
                    EmployeeStatusId = 1,
                    EmployeeNumber = "ANC12345"
                },
                new EmployeeData
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    EmailAddress = "jane.smith@example.com",
                    DateOfBirth = new DateTime(1985, 5, 15),
                    DepartmentId = 3,
                    EmployeeStatusId = 1,
                    EmployeeNumber = "WER67890"
                },
                new EmployeeData
                {
                    Id = 3,
                    FirstName = "Rob",
                    LastName = "Smith",
                    EmailAddress = "Rob.smith@example.com",
                    DateOfBirth = new DateTime(1992, 10, 15),
                    DepartmentId = 2,
                    EmployeeStatusId = 3,
                    EmployeeNumber = "EWS67890"
                }
            };
        }

        private List<EmployeeStatus> GetMockEmployeeStatusData()
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
