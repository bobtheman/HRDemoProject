namespace HRDemoProject.Controllers
{
    using HRDemoProject.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class EmployeeDataController : Controller
    {
        private readonly ILogger<EmployeeDataController> _logger;
        private readonly IApiDataService _apiDataService;

        public EmployeeDataController(ILogger<EmployeeDataController> logger, IApiDataService apiDataService)
        {
            _logger = logger;
            _apiDataService = apiDataService;
        }

        public IActionResult Index()
        {
            var employeeDataResponse = _apiDataService.GetFilteredEmployeeListAsync().Result;

            return View(employeeDataResponse);
        }
    }
}
