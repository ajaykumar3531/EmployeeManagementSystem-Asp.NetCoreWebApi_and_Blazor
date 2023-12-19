using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models.DTOS
{

    public class DepartmentDTO
    {
        [Required(ErrorMessage = "Department Name is required")]
        public string DepartmentName { get; set; } = null!;

        [Required(ErrorMessage = "Location is required")]
        public string? Location { get; set; }

        [Required(ErrorMessage = "Manager is required")]
        public string? Manager { get; set; }
    }

}
