using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Task:IEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
    }
}
