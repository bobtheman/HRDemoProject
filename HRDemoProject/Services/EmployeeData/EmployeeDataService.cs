﻿namespace HRDemoProject.Services.EmployeeData
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

        public async Task<EmployeeDataResponse> GetFilteredEmployeeListAsync(int? employeeId, int? employeeStatusId, int? departmentId)
        {
            var employeeDataResponse = new EmployeeDataResponse();

            var request = new RestRequest("api/Employee/GetFilteredEmployeelist", Method.Get);

            if (employeeId.HasValue)
            {
                request.AddParameter("Id", employeeId.Value);
            }

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

        public async Task<Result> CreateEmployeeDataAsync(EmployeeData employeeData)
        {
            var request = new RestRequest("api/Employee/CreateEmployeeData", Method.Post);
            request.AddJsonBody(employeeData);
            RestResponse response = await _client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<Result>(response.Content);
        }

        public async Task<Result> UpdateEmployeeDataAsync(EmployeeData employeeData)
        {
            var request = new RestRequest("api/Employee/UpdateEmployeeData", Method.Put);
            request.AddJsonBody(employeeData);
            RestResponse response = await _client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<Result>(response.Content);
        }

        public async Task<Result> DeleteEmployeeDataAsync(EmployeeData employeeData)
        {
            var request = new RestRequest("api/Employee/DeleteEmployeeData", Method.Delete);
            request.AddJsonBody(employeeData);
            RestResponse response = await _client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<Result>(response.Content);
        }
    }
}
