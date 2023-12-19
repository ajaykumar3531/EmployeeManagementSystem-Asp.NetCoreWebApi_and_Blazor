// UpdateBase.cs
using BlazorUI.Services.EmployeeServices;
using EMS.Models.DTOS;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorUI.Data
{
    public class UpdateBase : ComponentBase
    {
        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public EmployeeApiDTO updateEmployeeDto = new EmployeeApiDTO();

        [Parameter]
        public int EmployeeId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                updateEmployeeDto = await EmployeeService.GetEmployeeById(EmployeeId);
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine($"Error in OnInitializedAsync: {ex.Message}");
            }
        }

        public async Task UpdateEmployee()
        {
            try
            {
                updateEmployeeDto = await EmployeeService.UpdateEmployee(EmployeeId, updateEmployeeDto);
                Navigation.NavigateTo("/employee");
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine($"Error in UpdateEmployee: {ex.Message}");
            }
        }
    }
}
