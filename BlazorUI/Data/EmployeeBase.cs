using BlazorUI.Services.EmployeeServices;
using EMS.DataAccessLayer.Entities;
using EMS.Models.DTOS;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorUI.Data
{
    public class EmployeeComponentBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected List<Employee> Employees { get; set; } = new List<Employee>();
        protected int EmployeeIdToDelete { get; set; }
        protected  int id {  get; set; }
        protected ConfirmBase DeleteConfirmation { get; set; }
        


        protected updateDTO UpdateEmployeeDto { get; set; } = new updateDTO();

        protected override async Task OnInitializedAsync()
        {
            await LoadEmployees();
        }

        protected async Task LoadEmployees()
        {
            Employees = await EmployeeService.GetEmployees();

            // Assuming you want to retrieve the employee by ID before mapping
          
        }
       
        protected void Delete_Click(int employeeId)
        {
            EmployeeIdToDelete = employeeId;
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await EmployeeService.DeleteEmployee(EmployeeIdToDelete);
                NavigationManager.NavigateTo("/");
            }
        }

        
    }
}
