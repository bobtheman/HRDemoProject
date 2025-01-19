using HRDemoProject.Models.Department;
using HRDemoProject.Models.EmployeeStatus;
using HRDemoProject.Response.Department;
using HRDemoProject.Response.EmployeeStatus;
using Newtonsoft.Json;
using RestSharp;

namespace HRDemoProject.Services.EmployeeStatus
{
    public class EmployeeStatusDataSerivce : IEmployeeStatusDataSerivce
    {
        private readonly RestClient _client;
        private IConfiguration _configuration;

        public EmployeeStatusDataSerivce(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new RestClient(_configuration["HRDempApi:Url"]);
        }

        public async Task<EmployeeStatusDataResponse> GetFilteredDepartmentlistAsync()
        {
            var employeeStatusDataResponse = new EmployeeStatusDataResponse();

            var request = new RestRequest("api/EmployeeStatus/GetFilteredEmployeeStatuslist", Method.Get);

            RestResponse response = await _client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode && response.Content != null)
            {
                employeeStatusDataResponse.EmployeeStatusList = JsonConvert.DeserializeObject<List<EmployeeStatusData>>(response.Content);
            }

            return employeeStatusDataResponse;
        }
    }
}
