namespace HRDemoProject.Services.Department
{
    using HRDemoProject.Models.Department;
    using HRDemoProject.Response.Department;
    using Newtonsoft.Json;
    using RestSharp;

    public class DepartmentDataSerivce : IDepartmentDataSerivce
    {
        private readonly RestClient _client;
        private IConfiguration _configuration;

        public DepartmentDataSerivce(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new RestClient(_configuration["HRDempApi:Url"]);
        }

        public async Task<DepartmentDataResponse> GetFilteredDepartmentlistAsync()
        {
            var departmentDataResponse = new DepartmentDataResponse();

            var request = new RestRequest("api/Department/GetFilteredDepartmentlist", Method.Get);

            RestResponse response = await _client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode && response.Content != null)
            {
                departmentDataResponse.DepartmentDataList = JsonConvert.DeserializeObject<List<DepartmentData>>(response.Content);
            }

            return departmentDataResponse;
        }
    }
}
