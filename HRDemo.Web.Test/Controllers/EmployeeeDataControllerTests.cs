namespace HRDemo.Web.Test.Controllers
{
    using HRDemoProject.Controllers;
    using HRDemoProject.Models.Department;
    using HRDemoProject.Models.Employee;
    using HRDemoProject.Models.EmployeeStatus;
    using HRDemoProject.Response.Department;
    using HRDemoProject.Response.Employee;
    using HRDemoProject.Response.EmployeeStatus;
    using HRDemoProject.Services;
    using HRDemoProject.Services.Department;
    using HRDemoProject.Services.EmployeeData;
    using HRDemoProject.Services.EmployeeStatus;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Moq;

    public class EmployeeDataControllerTests
    {
        private readonly Mock<ILogger<EmployeeDataController>> _loggerMock;
        private readonly Mock<IEmployeeDataService> _employeeDataServiceMock;
        private readonly Mock<IDepartmentDataSerivce> _departmentDataSerivceMock;
        private readonly Mock<IEmployeeStatusDataSerivce> _employeeStatusDataSerivceMock;
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly EmployeeDataController _controller;

        public EmployeeDataControllerTests()
        {
            _loggerMock = new Mock<ILogger<EmployeeDataController>>();
            _employeeDataServiceMock = new Mock<IEmployeeDataService>();
            _departmentDataSerivceMock = new Mock<IDepartmentDataSerivce>();
            _employeeStatusDataSerivceMock = new Mock<IEmployeeStatusDataSerivce>();
            _configurationMock = new Mock<IConfiguration>();

            _controller = new EmployeeDataController(
                _loggerMock.Object,
                _employeeDataServiceMock.Object,
                _departmentDataSerivceMock.Object,
                _employeeStatusDataSerivceMock.Object,
                _configurationMock.Object);
        }

        [Fact]
        public void Index_ReturnsViewResult_WithEmployeeFiltersModel()
        {
            // Arrange
            var departmentDataResponse = new DepartmentDataResponse { DepartmentDataList = new List<DepartmentData>() };
            var employeeStatusDataResponse = new EmployeeStatusDataResponse { EmployeeStatusList = new List<EmployeeStatusData>() };
            _departmentDataSerivceMock.Setup(s => s.GetFilteredDepartmentlistAsync()).ReturnsAsync(departmentDataResponse);
            _employeeStatusDataSerivceMock.Setup(s => s.GetFilteredDepartmentlistAsync()).ReturnsAsync(employeeStatusDataResponse);
            _configurationMock.Setup(c => c["DataTableSettings:PageLength"]).Returns("10");

            // Act
            var result = _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<EmployeeFilters>(viewResult.Model);
            Assert.Equal(departmentDataResponse, model.DepartmentDataResponse);
            Assert.Equal(employeeStatusDataResponse, model.EmployeeStatusDataResponse);
            Assert.Equal(10, model.DataTableSettings.PageLength);
        }

        [Fact]
        public void GetFilteredData_ReturnsJsonResult_WithFilteredEmployeeList()
        {
            // Arrange
            var employeeDataResponse = new EmployeeDataResponse { EmployeeDataList = new List<EmployeeData>() };
            _employeeDataServiceMock.Setup(s => s.GetFilteredEmployeeListAsync(null, 1, 1)).ReturnsAsync(employeeDataResponse);

            // Act
            var result = _controller.GetFilteredData(1, 1);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            Assert.Equal(employeeDataResponse.EmployeeDataList, jsonResult.Value);
        }

        [Fact]
        public void CreatEmployeeData_ReturnsPartialViewResult_WithEmployeeFiltersModel()
        {
            // Arrange
            var departmentDataResponse = new DepartmentDataResponse { DepartmentDataList = new List<DepartmentData>() };
            var employeeStatusDataResponse = new EmployeeStatusDataResponse { EmployeeStatusList = new List<EmployeeStatusData>() };
            _departmentDataSerivceMock.Setup(s => s.GetFilteredDepartmentlistAsync()).ReturnsAsync(departmentDataResponse);
            _employeeStatusDataSerivceMock.Setup(s => s.GetFilteredDepartmentlistAsync()).ReturnsAsync(employeeStatusDataResponse);
            _configurationMock.Setup(c => c["DataTableSettings:PageLength"]).Returns("10");

            // Act
            var result = _controller.CreatEmployeeData();

            // Assert
            var partialViewResult = Assert.IsType<PartialViewResult>(result);
            var model = Assert.IsType<EmployeeFilters>(partialViewResult.Model);
            Assert.Equal(departmentDataResponse, model.DepartmentDataResponse);
            Assert.Equal(employeeStatusDataResponse, model.EmployeeStatusDataResponse);
            Assert.Equal(10, model.DataTableSettings.PageLength);
        }

        [Fact]
        public void EditEmployeeData_ReturnsPartialViewResult_WithEmployeeFiltersModel()
        {
            // Arrange
            var employeeDataResponse = new EmployeeDataResponse { EmployeeDataList = new List<EmployeeData> { new EmployeeData { Id = 1 } } };
            var departmentDataResponse = new DepartmentDataResponse { DepartmentDataList = new List<DepartmentData>() };
            var employeeStatusDataResponse = new EmployeeStatusDataResponse { EmployeeStatusList = new List<EmployeeStatusData>() };
            _employeeDataServiceMock.Setup(s => s.GetFilteredEmployeeListAsync(1, null, null)).ReturnsAsync(employeeDataResponse);
            _departmentDataSerivceMock.Setup(s => s.GetFilteredDepartmentlistAsync()).ReturnsAsync(departmentDataResponse);
            _employeeStatusDataSerivceMock.Setup(s => s.GetFilteredDepartmentlistAsync()).ReturnsAsync(employeeStatusDataResponse);
            _configurationMock.Setup(c => c["DataTableSettings:PageLength"]).Returns("10");

            // Act
            var result = _controller.EditEmployeeData(1);

            // Assert
            var partialViewResult = Assert.IsType<PartialViewResult>(result);
            var model = Assert.IsType<EmployeeFilters>(partialViewResult.Model);
            Assert.Equal(employeeDataResponse.EmployeeDataList.First(), model.EmployeeData);
            Assert.Equal(departmentDataResponse, model.DepartmentDataResponse);
            Assert.Equal(employeeStatusDataResponse, model.EmployeeStatusDataResponse);
            Assert.Equal(10, model.DataTableSettings.PageLength);
        }

        [Fact]
        public async Task SaveEmployeeData_ReturnsJsonResult_WithResult()
        {
            // Arrange
            var employeeData = new EmployeeData { Id = 1 };
            var result = new Result() { IsSuccess = true };
            _employeeDataServiceMock.Setup(s => s.UpdateEmployeeDataAsync(employeeData)).ReturnsAsync(result);

            // Act
            var jsonResult = await _controller.SaveEmployeeData(employeeData);

            // Assert
            var resultValue = Assert.IsType<JsonResult>(jsonResult);
            Assert.Equal(result, resultValue.Value);
        }

        [Fact]
        public async Task SaveEmployeeData_ReturnsJsonResult_WithFailureResult()
        {
            // Arrange
            var employeeData = new EmployeeData { Id = 1 };
            var result = new Result() { IsSuccess = false };
            _employeeDataServiceMock.Setup(s => s.UpdateEmployeeDataAsync(employeeData)).ReturnsAsync(result);

            // Act
            var jsonResult = await _controller.SaveEmployeeData(employeeData);

            // Assert
            var resultValue = Assert.IsType<JsonResult>(jsonResult);
            Assert.Equal(result, resultValue.Value);
        }
    }
}
