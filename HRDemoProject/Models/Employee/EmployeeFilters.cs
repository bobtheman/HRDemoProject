namespace HRDemoProject.Models.Employee
{
    using HRDemoProject.Models.FilterOptions;
    using HRDemoProject.Response.Department;
    using HRDemoProject.Response.EmployeeStatus;

    public class EmployeeFilters
    {
        public EmployeeData EmployeeData { get; set; } = new EmployeeData();
        public DepartmentDataResponse DepartmentDataResponse { get; set; } = new DepartmentDataResponse();
        public EmployeeStatusDataResponse EmployeeStatusDataResponse { get; set; } = new EmployeeStatusDataResponse();
        public DataTableSettings DataTableSettings { get; set; } = new DataTableSettings();
    }
}
