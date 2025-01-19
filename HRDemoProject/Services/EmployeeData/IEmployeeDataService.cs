namespace HRDemoProject.Services.EmployeeData
{
    using HRDemoProject.Response.Employee;

    public interface IEmployeeDataService
    {
        Task<EmployeeDataResponse> GetFilteredEmployeeListAsync(int? employeeId, int? employeeStatusId, int? departmentId);
    }
}
