namespace HRDemoProject.Services
{
    using HRDemoProject.Models.Employee;
    using HRDemoProject.Response.Employee;
    using Newtonsoft.Json;
    using RestSharp;

    public class ApiDataService : IApiDataService
    {
        private readonly RestClient _client;

        public ApiDataService()
        {
            _client = new RestClient("https://localhost:7110");
        }

        public async Task<EmployeeDataResponse> GetFilteredEmployeeListAsync()
        {
            var employeeDataResponse = new EmployeeDataResponse();

            var request = new RestRequest("api/Employee/GetFilteredEmployeelist", Method.Get);

            RestResponse response = await _client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode && response.Content != null)
            {
                employeeDataResponse.EmployeeDataList = JsonConvert.DeserializeObject<List<EmployeeData>>(response.Content);
            }

            return employeeDataResponse;
        }
    }
}
