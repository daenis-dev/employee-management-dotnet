using System.Net.Http.Headers;
using Newtonsoft.Json;
using EmployeeUI.Models;

public class EmployeeService
{
    private readonly HttpClient _httpClient;

    public EmployeeService()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<List<Employee>> GetEmployeesAsync()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:8080/employees");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(content))
            {
                var employees = JsonConvert.DeserializeObject<List<Employee>>(content);

                return employees ?? new List<Employee>();
            }
        }

        return new List<Employee>();
    }
}