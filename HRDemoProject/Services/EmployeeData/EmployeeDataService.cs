namespace HRDemoProject.Services.EmployeeData
{
    using HRDemoProject.Models.Employee;
    using HRDemoProject.Response.Employee;
    using Newtonsoft.Json;
    using RestSharp;

    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly RestClient _client;
        private IConfiguration _configuration;

        public EmployeeDataService(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new RestClient(_configuration["HRDempApi:Url"]);
        }

        public async Task<EmployeeDataResponse> GetFilteredEmployeeListAsync(int? employeeStatusId, int? departmentId)
        {
            var employeeDataResponse = new EmployeeDataResponse();

            var request = new RestRequest("api/Employee/GetFilteredEmployeelist", Method.Get);

            if (employeeStatusId.HasValue)
            {
                request.AddParameter("employeeStatusId", employeeStatusId.Value);
            }

            if (departmentId.HasValue)
            {
                request.AddParameter("departmentId", departmentId.Value);
            }

            RestResponse response = await _client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode && response.Content != null)
            {
                employeeDataResponse.EmployeeDataList = JsonConvert.DeserializeObject<List<EmployeeData>>(response.Content);
            }

            return employeeDataResponse;
        }
    }
}
