using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public IResult Add(Employee employee)
        {
            _employeeDal.Add(employee);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public IResult Delete(Employee employee)
        {
            _employeeDal.Delete(employee);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public IDataResult<List<Employee>> GetAll()
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(), Messages.SuccessList);
        }

        public IDataResult<List<EmployeeDetailDto>> GetByDepartmentId(int departmentId)
        {
            return new SuccessDataResult<List<EmployeeDetailDto>>(_employeeDal.GetEmployeesDetail(e => e.DepartmentId == departmentId));
        }

        public IDataResult<Employee> GetById(int employeeId)
        {
            return new SuccessDataResult<Employee>(_employeeDal.Get(e => e.Id == employeeId));
        }

        public IDataResult<EmployeeDetailDto> GetEmployeeDetails(int employeeId)
        {
            return new SuccessDataResult<EmployeeDetailDto>(_employeeDal.GetEmployeeDetail(employeeId));
        }

        public IDataResult<List<EmployeeDetailDto>> GetEmployeesDetails()
        {
            return new SuccessDataResult<List<EmployeeDetailDto>>(_employeeDal.GetEmployeesDetail());
        }

        public IResult Update(Employee employee)
        {
            _employeeDal.Update(employee);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
