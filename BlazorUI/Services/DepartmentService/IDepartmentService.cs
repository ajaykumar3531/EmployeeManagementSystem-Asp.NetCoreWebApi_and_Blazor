using EMS.DataAccessLayer.Entities;
using EMS.Models.DTOS;

namespace BlazorUI.Services.DepartmentService
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetDepartments();
        Task<bool> DeleteDepartment(int departmentId);
        Task<DepartmentDTO> UpdateDepartment(int departmentId, DepartmentDTO updatedDepartment);
        Task<bool> AddDepartment(DepartmentDTO departmentDto);
        Task<DepartmentDTO> GetDepartmentById(int departmentId);
    }

}
