using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEmployeeDal : EfEntityRepositoryBase<Employee, ProjectManagementContext>, IEmployeeDal
    {
        public EmployeeDetailDto GetEmployeeDetail(int employeeId)
        {
            using (ProjectManagementContext context = new ProjectManagementContext())
            {
                var result = from e in context.Employees.Where(x=>x.Id==employeeId)
                             join d in context.Departments on e.DepartmentId equals d.Id
                             select new EmployeeDetailDto
                             {
                                 Id = e.Id,
                                 DepartmentId = d.Id,
                                 Name = e.FirstName + " " + e.LastName,
                                 DepartmentName = d.Name,
                                 Email = e.Email,
                                 Salary = e.Salary,
                             };
                return result.SingleOrDefault();

            }
        }

        public List<EmployeeDetailDto> GetEmployeesDetail(Expression<Func<EmployeeDetailDto, bool>> filter = null)
        {
            using (ProjectManagementContext context = new ProjectManagementContext())
            {
                var result = from e in context.Employees
                             join d in context.Departments on e.DepartmentId equals d.Id
                             select new EmployeeDetailDto
                             {
                                 Id = e.Id,
                                 DepartmentId = d.Id,
                                 Name = e.FirstName + " " + e.LastName,
                                 DepartmentName = d.Name,
                                 Email = e.Email,
                                 Salary = e.Salary,
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();

            }
        }
    }
}
