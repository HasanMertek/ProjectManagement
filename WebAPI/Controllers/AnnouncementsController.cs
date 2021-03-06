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
    public class AnnouncementsController : ControllerBase
    {
        
       private IAnnouncementService _announcementService;

        public AnnouncementsController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _announcementService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int announcementId)
        {
            var result = _announcementService.GetById(announcementId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Announcement announcement)
        {
            var result = _announcementService.Add(announcement);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("delete")]
        public IActionResult Delete(Announcement announcement)
        {
            var result = _announcementService.Delete(announcement);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update(Announcement announcement)
        {
            var result = _announcementService.Update(announcement);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}

