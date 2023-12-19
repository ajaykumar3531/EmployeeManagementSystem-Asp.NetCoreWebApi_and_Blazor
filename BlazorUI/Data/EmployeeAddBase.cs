using BlazorUI.Services.EmployeeServices;
using EMS.Models.DTOS;
using Microsoft.AspNetCore.Components;

namespace BlazorUI.Data
{
    public class EmployeeAddBase : ComponentBase
    {
        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        protected EmployeeDTO registrationDto = new EmployeeDTO();

        protected override async Task OnInitializedAsync()
        {
            await RegisterEmployee();
        }
        protected async Task RegisterEmployee()
        {
            var success = await EmployeeService.AddEmployee(registrationDto);
            if (success)
            {
                Navigation.NavigateTo("/employee");
            }
        }
    }
}
