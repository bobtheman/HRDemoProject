namespace HRDemoProject.Services.Department
{
    using HRDemoProject.Response.Department;

    public interface IDepartmentDataSerivce
    {
        Task<DepartmentDataResponse> GetFilteredDepartmentlistAsync();
    }
}
