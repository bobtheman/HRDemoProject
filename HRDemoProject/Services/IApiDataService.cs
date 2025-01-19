namespace HRDemoProject.Services
{
    using HRDemoProject.Response.Employee;

    public interface IApiDataService
    {
        Task<EmployeeDataResponse> GetFilteredEmployeeListAsync();
    }
}
