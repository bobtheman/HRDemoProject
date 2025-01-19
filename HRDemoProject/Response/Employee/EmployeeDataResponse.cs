namespace HRDemoProject.Response.Employee
{
    using HRDemoProject.Models.Employee;

    public class EmployeeDataResponse
    {
        public List<EmployeeData> EmployeeDataList { get; set; } = new List<EmployeeData>();
    }
}
