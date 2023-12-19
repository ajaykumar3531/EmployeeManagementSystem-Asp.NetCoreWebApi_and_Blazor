using BlazorUI.Services.DepartmentService;
using BlazorUI.Services.DepartmentServices;
using EMS.DataAccessLayer.Entities;
using EMS.Models.DTOS;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorUI.Data.DepartmentBase
{
    public class DepartmentComponentBase : ComponentBase
    {
        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected List<Department> Departments { get; set; } = new List<Department>();
        protected int DepartmentIdToDelete { get; set; }
        protected int id { get; set; }
        protected ConfirmBase DeleteConfirmation { get; set; }

        protected DepartmentDTO UpdateDepartmentDto { get; set; } = new DepartmentDTO();

        protected override async Task OnInitializedAsync()
        {
            await LoadDepartments();
            StateHasChanged();
        }

        protected async Task LoadDepartments()
        {
            Departments = await DepartmentService.GetDepartments(); 
            
        }

        protected void Delete_Click(int departmentId)
        {
            DepartmentIdToDelete = departmentId;
            DeleteConfirmation.Show();
            
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await DepartmentService.DeleteDepartment(DepartmentIdToDelete);

                // Update the state to reflect the changes
                Departments = Departments.Where(d => d.DepartmentId != DepartmentIdToDelete).ToList();
                // Notify Blazor to re-render the component
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                    NavigationManager.NavigateTo("/");
                });
            }
        }

    }
}
