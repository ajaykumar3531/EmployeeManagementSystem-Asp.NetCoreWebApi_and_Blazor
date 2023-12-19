using EMS.BusinessLayer.Interfaces;

using EMS.DataAccessLayer.Interfaces;
using EMS.Models.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.DataAccessLayer.Entities;

namespace EMS.BusinessLayer.Implementations
{
    

    public class EmployeeAccess : IEmployeeAccess
    {
        private readonly IEMSDataAccess<Employee> _employeeRepo;

        public EmployeeAccess(IEMSDataAccess<Employee> employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<EmployeeDTO> DeleteEmployeeData(int id)
        {
            var data = await _employeeRepo.GetByIdAsync(id);
            if (data != null)
            {
                _employeeRepo.Remove(data);
                if (await _employeeRepo.SaveChangesAsync())
                {
                    return MapToDTO(data);
                }
            }
            return null;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var employeeData = await _employeeRepo.GetAllAsync();
            return employeeData.ToList();
        }


        public async Task<EmployeeApiDTO> GetEmployeeById(int id)
        {
            var data = await _employeeRepo.GetByIdAsync(id);

            if(data == null)
            {
                return null;
            }
            else
            {
                return MapToApiDTO(data);
            }
        }

        public async Task<EmployeeDTO> EmployeeRegistration(EmployeeDTO dto)
        {
            
                Employee employee = MapToEntity(dto);
                employee.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.PasswordHash);
                _employeeRepo.Add(employee);
                if (await _employeeRepo.SaveChangesAsync())
                {
                    return MapToDTO(employee);
                }
                else
                {
                    return null;
                }
            
            
        }

        public async Task<EmployeeApiDTO> UpdateEmployeeById(int id, EmployeeApiDTO updatedEmployeeDTO)
        {
            // Retrieve the existing employee data by ID
            var existingEmployee = await _employeeRepo.GetByIdAsync(id);

            if (existingEmployee == null)
            {
                // Handle the case where the employee with the specified ID is not found
                return null;
            }
            existingEmployee.FirstName = !string.IsNullOrWhiteSpace(updatedEmployeeDTO.FirstName) ? updatedEmployeeDTO.FirstName : existingEmployee.FirstName;
            existingEmployee.DepartmentId=!string.IsNullOrWhiteSpace(updatedEmployeeDTO.DepartmentId.ToString())?updatedEmployeeDTO.DepartmentId : existingEmployee.DepartmentId;
            existingEmployee.LastName = !string.IsNullOrWhiteSpace(updatedEmployeeDTO.LastName) ? updatedEmployeeDTO.LastName : existingEmployee.LastName;
            existingEmployee.DateOfBirth = updatedEmployeeDTO.DateOfBirth ?? existingEmployee.DateOfBirth; // Assuming DateOfBirth is nullable
            existingEmployee.PhoneNumber = !string.IsNullOrWhiteSpace(updatedEmployeeDTO.PhoneNumber) ? updatedEmployeeDTO.PhoneNumber : existingEmployee.PhoneNumber;
            existingEmployee.Email = !string.IsNullOrWhiteSpace(updatedEmployeeDTO.Email) ? updatedEmployeeDTO.Email : existingEmployee.Email;
            existingEmployee.HireDate = updatedEmployeeDTO.HireDate ?? existingEmployee.HireDate; // Assuming HireDate is nullable
            existingEmployee.JobTitle = !string.IsNullOrWhiteSpace(updatedEmployeeDTO.JobTitle) ? updatedEmployeeDTO.JobTitle : existingEmployee.JobTitle;
            existingEmployee.Hobbies = !string.IsNullOrWhiteSpace(updatedEmployeeDTO.Hobbies) ? updatedEmployeeDTO.Hobbies : existingEmployee.Hobbies;




           // Save the changes to the database
           _employeeRepo.Update(existingEmployee);

            if (await _employeeRepo.SaveChangesAsync())
            {
                // Mapping the updated employee data to DTO for response
                return MapToApiDTO(existingEmployee);
            }
            else
            {
                // Handle the case where the update fails
                return null;
            }
        }

        // Helper methods for mapping between entities and DTOs
        private EmployeeDTO MapToDTO(Employee employee)
        {
            return new EmployeeDTO
            {DepartmentId = employee.DepartmentId,
              
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                Gender = employee.Gender,
                Address = employee.Address,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
                HireDate = employee.HireDate,
                JobTitle = employee.JobTitle,
                Country = employee.Country,
                City = employee.City,
                Hobbies = employee.Hobbies,
                // Do not map the PasswordHash property to the DTO
            };
        }
        private Employee MapToEntity(EmployeeDTO dto)
        {
            return new Employee
            {
                DepartmentId = dto.DepartmentId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                HireDate = dto.HireDate,
                JobTitle = dto.JobTitle,
                Country = dto.Country,
                City = dto.City,
                Hobbies = dto.Hobbies,
                // Do not map the Password property to the entity
            };
        }
        private EmployeeApiDTO MapToApiDTO(Employee employee)
        {
            return new EmployeeApiDTO
            {
                DepartmentId = employee.DepartmentId,

                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
                HireDate = employee.HireDate,
                JobTitle = employee.JobTitle,
                Hobbies = employee.Hobbies,
                
            };
        }
        private Employee MapToApiEntity(EmployeeApiDTO dto)
        {
            return new Employee
            {
                DepartmentId = dto.DepartmentId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                HireDate = dto.HireDate,
                JobTitle = dto.JobTitle,
              
               
            };
        }
    }

}
