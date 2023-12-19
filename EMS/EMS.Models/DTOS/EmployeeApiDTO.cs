using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models.DTOS
{
    public class EmployeeApiDTO
    {
        
           
            public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }

        //public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        //public string? PasswordHash { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime? HireDate { get; set; }
        public string? JobTitle { get; set; }
        //public string? Country { get; set; }
        //public string? City { get; set; }
        public string? Hobbies { get; set; }

    }
}
