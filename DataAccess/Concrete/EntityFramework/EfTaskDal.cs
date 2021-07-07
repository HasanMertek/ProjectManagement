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
    public class EfTaskDal : EfEntityRepositoryBase<Task, ProjectManagementContext>, ITaskDal
    {
        public TaskDetailDto GetTaskDetails(int taskId)
        {
            using (ProjectManagementContext context=new ProjectManagementContext())
            {
                var result = from t in context.Tasks.Where(t => t.Id == taskId)
                             join e in context.Employees
                             on t.EmployeeId equals e.Id
                             join d in context.Departments
                             on e.DepartmentId equals d.Id
                             select new TaskDetailDto
                             {
                                 Id = t.Id,
                                 EmployeeId = e.Id,
                                 EmployeeName = $"{e.FirstName} {e.LastName}",
                                 Department = d.Name,
                                 Description = t.Description
                             };
                return result.SingleOrDefault();
            }
        }

        public List<TaskDetailDto> GetTasksDetails(Expression<Func<TaskDetailDto, bool>> filter = null)
        {
            using (ProjectManagementContext context = new ProjectManagementContext())
            {
                var result = from t in context.Tasks
                             join e in context.Employees
                             on t.EmployeeId equals e.Id
                             join d in context.Departments
                             on e.DepartmentId equals d.Id
                             select new TaskDetailDto
                             {
                                 Id = t.Id,
                                 EmployeeId = e.Id,
                                 EmployeeName = $"{e.FirstName} {e.LastName}",
                                 Department = d.Name,
                                 Description = t.Description
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}
