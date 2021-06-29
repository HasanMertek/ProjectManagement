using Business.Abstract;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class EmployeeImageManager : IEmployeeImageService
    {
        IEmployeeImageDal _employeeImageDal;

        public EmployeeImageManager(IEmployeeImageDal employeeImageDal)
        {
            _employeeImageDal = employeeImageDal;
        }

        public IResult Add(IFormFile formFile, EmployeeImage employeeImage)
        {
            employeeImage.ImagePath = FileHelper.Add(formFile);
            employeeImage.Date = DateTime.Now;
            _employeeImageDal.Add(employeeImage);
            return new SuccessResult();
        }

        public IResult Delete(EmployeeImage employeeImage)
        {
            _employeeImageDal.Delete(employeeImage);
            return new SuccessResult();
        }

        public IDataResult<List<EmployeeImage>> GetAll()
        {
            return new SuccessDataResult<List<EmployeeImage>>(_employeeImageDal.GetAll());
        }

        public IDataResult<List<EmployeeImage>> GetByEmployeeId(int employeeId)
        {
            return new SuccessDataResult<List<EmployeeImage>>(_employeeImageDal.GetAll(x => x.EmployeeId == employeeId));
        }

        public IDataResult<EmployeeImage> GetById(int employeeImageId)
        {
            return new SuccessDataResult<EmployeeImage>(_employeeImageDal.Get(x => x.Id == employeeImageId));

        }

        public IResult Update(IFormFile formFile, EmployeeImage employeeImage)
        {
            employeeImage.ImagePath = FileHelper.Update(_employeeImageDal.Get(x => x.Id == employeeImage.Id).ImagePath,formFile);
            employeeImage.Date = DateTime.Now;
            _employeeImageDal.Update(employeeImage);
            return new SuccessResult();
        }
    }
}
