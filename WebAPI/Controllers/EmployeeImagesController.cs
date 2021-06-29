using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeImagesController : ControllerBase
    {
        IEmployeeImageService _employeeImageService;

        public EmployeeImagesController(IEmployeeImageService employeeImageService)
        {
            _employeeImageService = employeeImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile formFile, [FromForm] EmployeeImage employeeImage)
        {
            var result = _employeeImageService.Add(formFile, employeeImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]

        public IActionResult Update([FromForm(Name =("Image"))] IFormFile formFile,[FromForm(Name =("Id"))] int Id)
        {
            var employeeImage = _employeeImageService.GetById(Id).Data;
            var result = _employeeImageService.Update(formFile, employeeImage);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public  IActionResult Delete([FromForm(Name =("Id"))] int Id)
        {
            var employeeImage = _employeeImageService.GetById(Id).Data;
            var result = _employeeImageService.Delete(employeeImage);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _employeeImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpGet("getimagesbyemployeeid")]

        public IActionResult GetImagesById(int id)
        {
            var result = _employeeImageService.GetByEmployeeId(id);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
    }
}
