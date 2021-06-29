﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
  public  class EmployeeImage:IEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string ImagePath { get; set; }

        public DateTime? Date { get; set; }
    }
}
