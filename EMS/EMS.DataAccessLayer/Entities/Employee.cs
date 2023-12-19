using System;
using System.Collections.Generic;

namespace EMS.DataAccessLayer.Entities;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public DateTime? HireDate { get; set; }

    public string? JobTitle { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? Hobbies { get; set; }

    public string? PasswordHash { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
}
