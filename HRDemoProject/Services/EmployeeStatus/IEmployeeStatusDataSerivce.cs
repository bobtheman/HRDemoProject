namespace HRDemoProject.Services.EmployeeStatus
{
    using HRDemoProject.Response.EmployeeStatus;

    public interface IEmployeeStatusDataSerivce
    {
        Task<EmployeeStatusDataResponse> GetFilteredDepartmentlistAsync();
    }
}
