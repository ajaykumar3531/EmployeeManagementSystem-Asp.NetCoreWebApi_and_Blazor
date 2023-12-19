using BlazorUI.Services.DepartmentService;
using BlazorUI.Services.EmployeeServices;
using EMS.DataAccessLayer.Entities;
using EMS.Models.DTOS;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlazorUI.Data.DepartmentBase
{
    public class UpdateDepartmentBase : ComponentBase
    {
        [Inject]
        protected IDepartmentService DepartmentService { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected DepartmentDTO addDepartment = new DepartmentDTO();

        [Parameter]
        public int DepartmentId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                addDepartment = await DepartmentService.GetDepartmentById(DepartmentId);
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine($"Error in OnInitializedAsync: {ex.Message}");
            }
        }

        public async Task UpdateDepartment()
        {
            try
            {
                addDepartment = await DepartmentService.UpdateDepartment(DepartmentId,addDepartment);
                NavigationManager.NavigateTo("/department");
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine($"Error in UpdateEmployee: {ex.Message}");
            }
        }
    }
}
