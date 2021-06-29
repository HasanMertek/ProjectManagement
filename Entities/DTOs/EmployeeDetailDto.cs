using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class EmployeeDetailDto
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public string DepartmentName { get; set; }

        public string Email { get; set; }
        public int Salary { get; set; }
    }
}
