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
    public class TaskManager : ITaskService
    {
        ITaskDal _taskDal;

        public TaskManager(ITaskDal taskDal)
        {
            _taskDal = taskDal;
        }

        public IResult Add(Task task)
        {
            
            _taskDal.Add(task);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public IResult Delete(Task task)
        {
            _taskDal.Delete(task);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public IDataResult<List<Task>> GetAll()
        {
            return new SuccessDataResult<List<Task>>(_taskDal.GetAll(),Messages.SuccessList);
        }

        public IDataResult<List<TaskDetailDto>> GetByEmployeeId(int employeeId)
        {
            return new SuccessDataResult<List<TaskDetailDto>>(_taskDal.GetTasksDetails(x => x.EmployeeId == employeeId));
        }

        public IDataResult<Task> GetById(int taskId)
        {
            return new SuccessDataResult<Task>(_taskDal.Get(x => x.Id == taskId));
        }

        public IDataResult<TaskDetailDto> GetTaskDetails(int taskId)
        {
            return new SuccessDataResult<TaskDetailDto>(_taskDal.GetTaskDetails(taskId));
        }

        public IDataResult<List<TaskDetailDto>> GetTasksDetails()
        {
            return new SuccessDataResult<List<TaskDetailDto>>(_taskDal.GetTasksDetails());
        }

        public IResult Update(Task task)
        {
            _taskDal.Update(task);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
