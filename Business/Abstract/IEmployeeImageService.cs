using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public  interface IEmployeeImageService
    {
        IDataResult<List<EmployeeImage>> GetAll();
        IDataResult<EmployeeImage> GetById(int employeeImageId);
        IDataResult<List<EmployeeImage>> GetByEmployeeId(int employeeId);
        IResult Add(IFormFile formFile, EmployeeImage employeeImage);
        IResult Delete( EmployeeImage employeeImage);
        IResult Update(IFormFile formFile, EmployeeImage employeeImage);
    }
}
