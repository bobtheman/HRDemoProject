namespace HRDemoProject.Services.EmployeeData
{
    using HRDemoProject.Models.Employee;
    using HRDemoProject.Response.Employee;

    public interface IEmployeeDataService
    {
        Task<EmployeeDataResponse> GetFilteredEmployeeListAsync(int? employeeId, int? employeeStatusId, int? departmentId);
        Task<Result> CreateEmployeeDataAsync(EmployeeData employeeData);
        Task<Result> UpdateEmployeeDataAsync(EmployeeData employeeData);
        Task<Result> DeleteEmployeeDataAsync(EmployeeData employeeData);
    }
}
