using System.Collections.Generic;
using System.Threading.Tasks;
using EMS.BusinessLayer.Interfaces;
using EMS.Models.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentAccess _departmentAccess;
        public DepartmentController(IDepartmentAccess departmentAccess)
        {
            _departmentAccess = departmentAccess;
        }

        [HttpGet]
        [Route("GetAllDepartments")]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _departmentAccess.GetAllDepartments();
            return Ok(departments);
        }

        [HttpGet("{departmentId}")]
       
        public async Task<IActionResult> GetDepartmentById(int departmentId)
        {
            var department = await _departmentAccess.GetDepartmentById(departmentId);

            if (department == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Department Not Found",
                    Success = false
                });
            }
            return Ok(department);


        }


        [HttpPost]
        public async Task<IActionResult> DepartmentRegistration(DepartmentDTO departmentDTO)
        {
            var registeredDepartment = await _departmentAccess.DepartmentRegistration(departmentDTO);

            if (registeredDepartment == null)
            {
                return BadRequest();
            }

            return Ok(registeredDepartment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartmentById(int id, DepartmentDTO updatedDepartmentDTO)
        {
            var updatedDepartment = await _departmentAccess.UpdateDepartmentById(id, updatedDepartmentDTO);

            if (updatedDepartment == null)
            {
                return NotFound();
            }

            return Ok(updatedDepartment);
        }

        [HttpDelete("{id}")]
     
        public async Task<IActionResult> DeleteDepartmentData(int id)
        {
            var deletedDepartment = await _departmentAccess.DeleteDepartmentData(id);

            if (deletedDepartment == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
