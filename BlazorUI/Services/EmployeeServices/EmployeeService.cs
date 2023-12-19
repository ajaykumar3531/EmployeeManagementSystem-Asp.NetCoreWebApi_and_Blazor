using EMS.DataAccessLayer.Entities;
using EMS.Models.DTOS;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorUI.Services.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            try
            {
                var employees = await _httpClient.GetFromJsonAsync<List<Employee>>("api/Employee/GetAllEmployees");
                if (employees == null)
                {
                    return null;
                }
                else
                {
                    return employees;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error getting employees: {ex.Message}");
              
                throw;
            }
        }

        public async Task<bool> DeleteEmployee(int employeeId)
        {
            try
            {
                await _httpClient.DeleteAsync($"api/Employee/{employeeId}");

                return true;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error deleting employee: {ex.Message}");
                
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error deleting employee: {ex.Message}");
                throw;
            }
        }
        public async Task<EmployeeApiDTO> UpdateEmployee(int employeeId, EmployeeApiDTO updateEmployee)
        {
            var response = await _httpClient.PutAsJsonAsync<EmployeeApiDTO>($"api/Employee/{employeeId}", updateEmployee);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<EmployeeApiDTO>();
            }
            else
            {
                
                return null;
            }
        }
        public async Task<bool> AddEmployee(EmployeeDTO employeeDto)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"api/Employee", employeeDto);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error adding employee: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public async Task<EmployeeApiDTO> GetEmployeeById(int employeeId)
        {
      
            var response = await _httpClient.GetFromJsonAsync<EmployeeApiDTO>($"/api/Employee/{employeeId}");

            if (response != null)
            {
                return response;
            }
            else
            {
                
                return null;
            }
        }
    }
}
