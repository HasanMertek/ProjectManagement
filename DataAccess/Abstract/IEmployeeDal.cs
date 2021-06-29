using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public  interface IEmployeeDal:IEntityRepository<Employee>
    {
        List<EmployeeDetailDto> GetEmployeesDetail(Expression<Func<EmployeeDetailDto, bool>> filter = null);
        EmployeeDetailDto GetEmployeeDetail(int employeeId);

    }
}
