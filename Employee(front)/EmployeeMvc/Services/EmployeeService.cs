using System.Text.Json;
using System.Text;
using EmployeeMvc.Models;


namespace EmployeeMvc.Services
{

    public class EmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            var content = new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/employees", content);
            response.EnsureSuccessStatusCode();
        }


    }

}
