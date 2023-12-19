using EMS.DataAccessLayer.Entities;
using EMS.Models.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BusinessLayer.Interfaces
{
    public interface IDepartmentAccess
    {
        Task<List<Department>> GetAllDepartments();
        Task<DepartmentDTO> DepartmentRegistration(DepartmentDTO dto);
        Task<DepartmentDTO> GetDepartmentById(int id);
        Task<DepartmentDTO> DeleteDepartmentData(int id);
        Task<DepartmentDTO> UpdateDepartmentById(int id, DepartmentDTO updatedDepartmentDTO);

    }
}
