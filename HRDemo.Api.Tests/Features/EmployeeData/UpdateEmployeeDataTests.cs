namespace HRDemo.Api.Tests.Features.EmployeeData
{
    using FluentAssertions;
    using FluentValidation;
    using FluentValidation.Results;
    using HRDemo.Api.Database;
    using HRDemo.Api.Entities;
    using HRDemo.Api.Features.EmployeeData.CreateEmployeeData;
    using HRDemo.Api.Features.EmployeeData.UpdateEmployeeData;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Moq.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class UpdateEmployeeDataTests
    {
        private readonly Mock<AppDbContext> _dbContextMock;
        private readonly Mock<IValidator<UpdateEmployeeData.Command>> _validatorMock;
        private readonly UpdateEmployeeData.Handler _handler;

        public UpdateEmployeeDataTests()
        {
            _validatorMock = new Mock<IValidator<UpdateEmployeeData.Command>>();
            _dbContextMock = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            _dbContextMock.Setup(db => db.EmployeeData).ReturnsDbSet(GetMockEmployeeDataList());
            _dbContextMock.Setup(db => db.EmployeeStatus).ReturnsDbSet(GetMockEmployeeStatusData());
            _handler = new UpdateEmployeeData.Handler(_dbContextMock.Object, _validatorMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailure_WhenValidationFails()
        {
            // Arrange
            var command = new UpdateEmployeeData.Command();
            var validationResult = new FluentValidation.Results.ValidationResult(new[] { new FluentValidation.Results.ValidationFailure("FirstName", "First name is required") });
            _validatorMock.Setup(v => v.Validate(command)).Returns(validationResult);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal("UpdateEmployeeData.Validation", result.Error.Code);
        }

        [Fact]
        public async Task Handle_ShouldReturnSuccess_WhenDataIsValid()
        {
            // Arrange
            var command = new UpdateEmployeeData.Command
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                EmailAddress = "john.doe@example.com",
                DateOfBirth = new DateTime(1990, 1, 1),
                DepartmentId = 1,
                EmployeeStatusId = 1,
                EmployeeNumber = "EMP001"
            };

            _validatorMock.Setup(v => v.Validate(command)).Returns(new ValidationResult());
            _dbContextMock.Setup(db => db.EmployeeData).ReturnsDbSet(GetMockEmployeeData());

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(command.Id);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailure_WhenEmailAlreadyExists()
        {
            // Arrange
            var command = new UpdateEmployeeData.Command
            {
                Id = 9,
                FirstName = "John",
                LastName = "Doe",
                EmailAddress = "john.doe@example.com",
                DateOfBirth = new DateTime(1990, 1, 1),
                DepartmentId = 1,
                EmployeeStatusId = 1,
                EmployeeNumber = "ANC12345"
            };

            _validatorMock.Setup(v => v.Validate(command)).Returns(new ValidationResult());
            _dbContextMock.Setup(db => db.EmployeeData).ReturnsDbSet(GetMockEmployeeDataList());

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Code.Should().Be("UpdateEmployeeData.DuplicateEmail");
        }

        [Fact]
        public async Task Handle_ShouldReturnFailure_WhenEmployeeNumberAlreadyExists()
        {
            // Arrange
            var command = new UpdateEmployeeData.Command
            {
                Id = 9,
                FirstName = "John",
                LastName = "Doe",
                EmailAddress = "rob.doe@example.com",
                DateOfBirth = new DateTime(1990, 1, 1),
                DepartmentId = 1,
                EmployeeStatusId = 1,
                EmployeeNumber = "ANC12345"
            };

            _validatorMock.Setup(v => v.Validate(command)).Returns(new ValidationResult());
            _dbContextMock.Setup(db => db.EmployeeData).ReturnsDbSet(GetMockEmployeeDataList());

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal("UpdateEmployeeData.DuplicateEmployeeNumber", result.Error.Code);
        }

        private List<EmployeeData> GetMockEmployeeDataList()
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

        private IEnumerable<EmployeeData> GetMockEmployeeData()
        {
            var data = GetMockEmployeeDataList().FirstOrDefault();
            return data != null ? new List<EmployeeData> { data } : Enumerable.Empty<EmployeeData>();
        }
    }
}
