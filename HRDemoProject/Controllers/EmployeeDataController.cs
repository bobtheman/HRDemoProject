namespace HRDemoProject.Controllers
{
    using HRDemoProject.Models.Employee;
    using HRDemoProject.Models.FilterOptions;
    using HRDemoProject.Services.Department;
    using HRDemoProject.Services.EmployeeData;
    using HRDemoProject.Services.EmployeeStatus;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

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
            var filteredEmployees = _employeeDataService.GetFilteredEmployeeListAsync(null, employeeStatusId, departmentId).Result;
            return Json(filteredEmployees.EmployeeDataList);
        }

        [HttpPost]
        public IActionResult CreatEmployeeData()
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

            return PartialView("_CreateEditEmployeeData", model);
        }

        [HttpPost]
        public IActionResult EditEmployeeData(int employeeId)
        {
            var employees = _employeeDataService.GetFilteredEmployeeListAsync(employeeId, null, null).Result;

            var model = new EmployeeFilters()
            {
                EmployeeData = employees.EmployeeDataList.FirstOrDefault() ?? new EmployeeData(),
                DepartmentDataResponse = _departmentDataSerivce.GetFilteredDepartmentlistAsync().Result,
                EmployeeStatusDataResponse = _employeeStatusDataSerivce.GetFilteredDepartmentlistAsync().Result,
                DataTableSettings = new DataTableSettings()
                {
                    PageLength = Convert.ToInt32(_configuration["DataTableSettings:PageLength"]),
                }
            };

            return PartialView("_CreateEditEmployeeData", model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveEmployeeData(EmployeeData employeeData)
        {
            bool isSuccess = false;

            if (employeeData.Id == 0)
            {
                isSuccess = await CreateEmployeeData(employeeData);
            }
            else
            {
                isSuccess = await UpdateEmployeeData(employeeData);
            }

            return Json(isSuccess);
        }

        private async Task<bool> CreateEmployeeData(EmployeeData employeeData)
        {
            try
            {
                return false;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error while creating employee data");
                return false;
            }
        }

        private async Task<bool> UpdateEmployeeData(EmployeeData employeeData)
        {
            try
            {
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating employee data");
                return false;
            }
        }
    }
}
