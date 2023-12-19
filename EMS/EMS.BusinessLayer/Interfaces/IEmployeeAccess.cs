using Azure;
using EMS.DataAccessLayer.Entities;

using EMS.Models.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BusinessLayer.Interfaces
{
    public interface IEmployeeAccess
    {
        // Employees
        Task<List<Employee>> GetAllEmployees();
        Task<EmployeeDTO> EmployeeRegistration(EmployeeDTO dtp);
        Task<EmployeeApiDTO> GetEmployeeById(int id);
        Task<EmployeeDTO> DeleteEmployeeData(int id);
        Task<EmployeeApiDTO> UpdateEmployeeById(int id, EmployeeApiDTO updatedEmployeeDTO);
    }

}
