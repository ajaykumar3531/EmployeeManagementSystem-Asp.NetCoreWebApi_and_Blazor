using BlazorUI.Services.DepartmentService;
using EMS.Models.DTOS;
using Microsoft.AspNetCore.Components;

namespace BlazorUI.Data.DepartmentBase
{
    public class AddDepartmentBase : ComponentBase
    {
        [Inject]
        protected IDepartmentService DepartmentService { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected DepartmentDTO addDepartment = new DepartmentDTO();

        protected override async Task OnInitializedAsync()
        {
            await AddDepartment();
        }

        protected async Task AddDepartment()
        {
            var success = await DepartmentService.AddDepartment(addDepartment);
            if (success)
            {
                NavigationManager.NavigateTo("/department");
            }
        }
    }
}
