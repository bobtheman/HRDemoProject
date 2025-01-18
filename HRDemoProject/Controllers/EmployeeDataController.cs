namespace HRDemoProject.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class EmployeeDataController : Controller
    {
        private readonly ILogger<EmployeeDataController> _logger;

        public EmployeeDataController(ILogger<EmployeeDataController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
