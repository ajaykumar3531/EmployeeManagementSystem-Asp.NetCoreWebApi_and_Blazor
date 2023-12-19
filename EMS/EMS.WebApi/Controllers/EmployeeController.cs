using System.Collections.Generic;
using System.Threading.Tasks;
using EMS.BusinessLayer.Interfaces;
using EMS.Models.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeAccess _employeeAccess;

        public EmployeeController(IEmployeeAccess employeeAccess)
        {
            _employeeAccess = employeeAccess;
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeAccess.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployeeById(int employeeId)
        {
            var employee = await _employeeAccess.GetEmployeeById(employeeId);

            if (employee == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,

                    Message = "Employee Not Found",

                    Success = false
                });
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeRegistration(EmployeeDTO employeeDTO)
        {
            var registeredEmployee = await _employeeAccess.EmployeeRegistration(employeeDTO);

            if (registeredEmployee == null)
            {
                return BadRequest();
            }

            return Ok(registeredEmployee);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeById(int id, EmployeeApiDTO updatedEmployeeDTO)
        {
            var updatedEmployee = await _employeeAccess.UpdateEmployeeById(id, updatedEmployeeDTO);

            if (updatedEmployee == null)
            {
                return NotFound();
            }

            return Ok(updatedEmployee);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeData(int id)
        {
            var deletedEmployee = await _employeeAccess.DeleteEmployeeData(id);

            if (deletedEmployee == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
