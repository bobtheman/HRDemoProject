using HRDemoProject.Models.Department;
using HRDemoProject.Models.EmployeeStatus;

namespace HRDemoProject.Response.EmployeeStatus
{
    public class EmployeeStatusDataResponse
    {
        public List<EmployeeStatusData> EmployeeStatusList { get; set; } = new List<EmployeeStatusData>();
    }
}
