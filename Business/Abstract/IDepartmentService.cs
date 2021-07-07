using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IDepartmentService
    {
        IDataResult<List<Department>> GetAll();
        IResult Add(Department department);
        IResult Delete(Department department);
        IResult Update(Department department);

        IDataResult<Department> GetById(int departmentId);

    }
}
