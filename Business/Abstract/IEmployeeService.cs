using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IDataResult<List<Employee>> GetAll();
        IDataResult<List<EmployeeDetailDto>> GetByDepartmentId(int departmentId);
        IDataResult<Employee> GetById(int employeeId);
        IDataResult<List<EmployeeDetailDto>> GetEmployeesDetails();
        IDataResult<EmployeeDetailDto> GetEmployeeDetails(int employeeId);
        IResult Add(Employee employee);
        IResult Delete(Employee employee);
        IResult Update(Employee employee);
    }
}
