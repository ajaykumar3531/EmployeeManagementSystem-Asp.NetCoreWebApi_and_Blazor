using System;
using System.Collections.Generic;

namespace EMS.DataAccessLayer.Entities;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public string? Location { get; set; }

    public string? Manager { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
