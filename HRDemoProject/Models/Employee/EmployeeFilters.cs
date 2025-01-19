namespace HRDemoProject.Models.Employee
{
    using HRDemoProject.Response.Department;
    using HRDemoProject.Response.Employee;
    using HRDemoProject.Response.EmployeeStatus;

    public class EmployeeFilters
    {
        public DepartmentDataResponse DepartmentDataResponse { get; set; } = new DepartmentDataResponse();
        public EmployeeStatusDataResponse EmployeeStatusDataResponse { get; set; } = new EmployeeStatusDataResponse();
    }
}
