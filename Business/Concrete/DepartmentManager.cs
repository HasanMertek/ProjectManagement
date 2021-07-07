using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        //[ValidationAspect(typeof(DepartmentValidator))]
        public IResult Add(Department department)
        {
            _departmentDal.Add(department);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public IResult Delete(Department department)
        {
            _departmentDal.Delete(department);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public IDataResult<List<Department>> GetAll()
        {
            return new SuccessDataResult<List<Department>>(_departmentDal.GetAll(), Messages.SuccessList);
        }

        public IDataResult<Department> GetById(int departmentId)
        {
            return new SuccessDataResult<Department>(_departmentDal.Get(x => x.Id == departmentId), Messages.SuccesFind);
        }

        public IResult Update(Department department)
        {
            _departmentDal.Update(department);
            return new SuccessResult(Messages.SuccessUpdated);

        }
    }
}
