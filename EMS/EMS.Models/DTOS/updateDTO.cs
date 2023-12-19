using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models.DTOS
{
    public class updateDTO
    {
        public int EmployeeId {  get; set; }
            public string FirstName { get; set; } = null!;
            public string LastName { get; set; } = null!;

            
            public DateTime? DateOfBirth { get; set; }

        
            public string? Gender { get; set; }
            public string? Address { get; set; }

           
            [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Mobile number must start with 6, 7, 8, or 9 and have a total of 10 digits.")]
            public string? PhoneNumber { get; set; }

            [Required(ErrorMessage = "Email is required!")]
            [RegularExpression(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$", ErrorMessage = "Invalid Email Address.")]
            public string? Email { get; set; }
            [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Password must be at least 8 characters long and include both letters and numbers.")]
            public string? PasswordHash { get; set; }

            [Required(ErrorMessage ="Department Id is required!")]
            public int? DepartmentId { get; set; }

        
            public DateTime? HireDate { get; set; }

            
            public string? JobTitle { get; set; }

           
            public string? Country { get; set; }

         
            public string? City { get; set; }

            
            public string? Hobbies { get; set; }
        }
    
}
