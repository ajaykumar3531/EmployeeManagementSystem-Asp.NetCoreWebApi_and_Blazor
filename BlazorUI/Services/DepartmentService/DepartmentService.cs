using BlazorUI.Services.DepartmentService;
using EMS.DataAccessLayer.Entities;
using EMS.Models.DTOS;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorUI.Services.DepartmentServices
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _httpClient;

        public DepartmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Department>> GetDepartments()
        {
            try
            {
                var departments = await _httpClient.GetFromJsonAsync<List<Department>>("api/Department/GetAllDepartments");
                if (departments == null)
                {
                    return null;
                }
                else
                {
                    return departments;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error getting departments: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeleteDepartment(int departmentId)
        {
            try
            {
                await _httpClient.DeleteAsync($"api/Department/{departmentId}");

                return true;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error deleting department: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error deleting department: {ex.Message}");
                throw;
            }
        }

        public async Task<DepartmentDTO> UpdateDepartment(int departmentId, DepartmentDTO updatedDepartment)
        {
            var response = await _httpClient.PutAsJsonAsync<DepartmentDTO>($"api/Department/{departmentId}", updatedDepartment);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<DepartmentDTO>();
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> AddDepartment(DepartmentDTO departmentDto)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Department", departmentDto);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error adding department: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }


        public async Task<DepartmentDTO> GetDepartmentById(int departmentId)
        {
            var response = await _httpClient.GetFromJsonAsync<DepartmentDTO>($"/api/Department/{departmentId}");

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
