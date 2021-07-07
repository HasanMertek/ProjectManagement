using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ITaskDal: IEntityRepository<Task>
    {
        List<TaskDetailDto> GetTasksDetails(Expression<Func<TaskDetailDto, bool>> filter = null);
        TaskDetailDto GetTaskDetails(int taskId);

    }
}
