using EMS.DataAccessLayer.Entities;
using EMS.Models.DTOS;

namespace BlazorUI.Services.EmployeeServices
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();
        Task<bool> DeleteEmployee(int employeeId);
        Task<EmployeeApiDTO> UpdateEmployee(int empId, EmployeeApiDTO updatedEmployee);
        Task<bool> AddEmployee(EmployeeDTO employeeDto);
        Task<EmployeeApiDTO> GetEmployeeById(int employeeID);
    }
}
