namespace HRDemoProject.Controllers
{
    using HRDemoProject.Models.Employee;
    using HRDemoProject.Models.FilterOptions;
    using HRDemoProject.Services.Department;
    using HRDemoProject.Services.EmployeeData;
    using HRDemoProject.Services.EmployeeStatus;
    using Microsoft.AspNetCore.Mvc;

    public class EmployeeDataController : Controller
    {
        private readonly ILogger<EmployeeDataController> _logger;
        private readonly IEmployeeDataService _employeeDataService;
        private readonly IDepartmentDataSerivce _departmentDataSerivce;
        private readonly IEmployeeStatusDataSerivce _employeeStatusDataSerivce;
        private readonly IConfiguration _configuration;

        public EmployeeDataController(
            ILogger<EmployeeDataController> logger,
            IEmployeeDataService employeeDataService,
            IDepartmentDataSerivce departmentDataSerivce,
            IEmployeeStatusDataSerivce employeeStatusDataSerivce,
            IConfiguration configuration)
        {
            _logger = logger;
            _employeeDataService = employeeDataService;
            _departmentDataSerivce = departmentDataSerivce;
            _employeeStatusDataSerivce = employeeStatusDataSerivce;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var model = new EmployeeFilters()
            {
                DepartmentDataResponse = _departmentDataSerivce.GetFilteredDepartmentlistAsync().Result,
                EmployeeStatusDataResponse = _employeeStatusDataSerivce.GetFilteredDepartmentlistAsync().Result,
                DataTableSettings = new DataTableSettings()
                {
                    PageLength = Convert.ToInt32(_configuration["DataTableSettings:PageLength"]),
                }
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
