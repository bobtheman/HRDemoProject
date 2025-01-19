namespace HRDemoProject.Controllers
{
    using HRDemoProject.Models.Employee;
    using HRDemoProject.Models.Filter;
    using HRDemoProject.Services.Department;
    using HRDemoProject.Services.EmployeeData;
    using HRDemoProject.Services.EmployeeStatus;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class EmployeeDataController : Controller
    {
        private readonly ILogger<EmployeeDataController> _logger;
        private readonly IEmployeeDataService _employeeDataService;
        private readonly IDepartmentDataSerivce _departmentDataSerivce;
        private readonly IEmployeeStatusDataSerivce _employeeStatusDataSerivce;

        public EmployeeDataController(
            ILogger<EmployeeDataController> logger, 
            IEmployeeDataService employeeDataService,
            IDepartmentDataSerivce departmentDataSerivce,
            IEmployeeStatusDataSerivce employeeStatusDataSerivce)
        {
            _logger = logger;
            _employeeDataService = employeeDataService;
            _departmentDataSerivce = departmentDataSerivce;
            _employeeStatusDataSerivce = employeeStatusDataSerivce;
        }

        public IActionResult Index()
        {
            var model = new EmployeeFilters()
            {
                DepartmentDataResponse = _departmentDataSerivce.GetFilteredDepartmentlistAsync().Result,
                EmployeeStatusDataResponse = _employeeStatusDataSerivce.GetFilteredDepartmentlistAsync().Result
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult GetFilteredData(int employeeStatusId, int departmentId)
        {
            var filteredEmployees = _employeeDataService.GetFilteredEmployeeListAsync(employeeStatusId, departmentId).Result;
            return Json(filteredEmployees.EmployeeDataList);
        }
    }
}
