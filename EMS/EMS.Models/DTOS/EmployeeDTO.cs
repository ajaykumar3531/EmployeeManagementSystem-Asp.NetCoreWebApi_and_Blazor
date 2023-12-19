using System;
using System.ComponentModel.DataAnnotations;

namespace EMS.Models.DTOS
{
    public class EmployeeDTO
    {
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Date of Birth is required.")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Mobile number must start with 6, 7, 8, or 9 and have a total of 10 digits.")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [RegularExpression(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$", ErrorMessage = "Invalid Email Address.")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$",
         ErrorMessage = "Password must be at least 8 characters long and include at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string? PasswordHash { get; set; }


        [Required(ErrorMessage = "Department Id is Required!")]
        public int? DepartmentId { get; set; }

        [Required(ErrorMessage = "Hire Date is required.")]
        public DateTime? HireDate { get; set; }

        [Required(ErrorMessage = "Job Title is required.")]
        public string? JobTitle { get; set; }

        [Required(ErrorMessage = " Country is required.")]
        public string? Country { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Hobbies are required.")]
        public string? Hobbies { get; set; }
    }
}
