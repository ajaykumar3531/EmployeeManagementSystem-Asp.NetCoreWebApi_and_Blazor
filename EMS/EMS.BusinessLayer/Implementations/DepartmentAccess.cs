using EMS.BusinessLayer.Interfaces;
using EMS.DataAccessLayer.Entities;
using EMS.DataAccessLayer.Interfaces;
using EMS.Models.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BusinessLayer.Implementations
{
    public class DepartmentAccess : IDepartmentAccess
    {
        private readonly IEMSDataAccess<Department> _departmentRepo;

        public DepartmentAccess(IEMSDataAccess<Department> departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            var departmentData = await _departmentRepo.GetAllAsync();
            return departmentData.ToList();
        }

        public async Task<DepartmentDTO> DepartmentRegistration(DepartmentDTO dto)
        {
        

            Department department = MapToEntity(dto);

            _departmentRepo.Add(department);

            if (await _departmentRepo.SaveChangesAsync())
            {
                return MapToDTO(department);
            }
            else
            {
                return null;
            }
        }

        public async Task<DepartmentDTO> GetDepartmentById(int id)
        {
            var data = await _departmentRepo.GetByIdAsync(id);
            if(data == null)
            {
                return null;
            }
            else
            {
                return MapToDTO(data);

            }
          
        }
        public async Task<DepartmentDTO> UpdateDepartmentById(int id, DepartmentDTO updatedDepartmentDTO)
        {
            var existingDepartment = await _departmentRepo.GetByIdAsync(id);

            if (existingDepartment == null)
            {
                return null; // Department not found
            }

            // Update the existing department data with the new values
            existingDepartment.DepartmentName = updatedDepartmentDTO.DepartmentName;
            existingDepartment.Location = updatedDepartmentDTO.Location;
            existingDepartment.Manager = updatedDepartmentDTO.Manager;

            _departmentRepo.Update(existingDepartment);

            if (await _departmentRepo.SaveChangesAsync())
            {
                return MapToDTO(existingDepartment);
            }
            else
            {
                return null; // Handle the case where the update fails
            }
        }


        public async Task<DepartmentDTO> DeleteDepartmentData(int id)
        {
            var data = await _departmentRepo.GetByIdAsync(id);
            if (data != null)
            {
                _departmentRepo.Remove(data);
                if (await _departmentRepo.SaveChangesAsync())
                {
                    return MapToDTO(data);
                }
            }
            return null;
        }

        // Helper methods for mapping between entities and DTOs

        private DepartmentDTO MapToDTO(Department department)
        {
            return new DepartmentDTO
            {
                DepartmentName = department.DepartmentName,
                Location = department.Location,
                Manager = department.Manager
            };
        }

        private Department MapToEntity(DepartmentDTO dto)
        {
            return new Department
            {
                DepartmentName = dto.DepartmentName,
                Location = dto.Location,
                Manager = dto.Manager
            };
        }
    }

}
