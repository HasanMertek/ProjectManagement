using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITaskService
    {
        IDataResult<List<Task>> GetAll();
        IDataResult<List<TaskDetailDto>> GetByEmployeeId(int employeeId);
        IDataResult<List<TaskDetailDto>> GetTasksDetails();
        IDataResult<TaskDetailDto> GetTaskDetails(int taskId);
        IResult Add(Task task);
        IResult Delete(Task task);
        IResult Update(Task task);

        IDataResult<Task> GetById(int taskId);
    }

}
