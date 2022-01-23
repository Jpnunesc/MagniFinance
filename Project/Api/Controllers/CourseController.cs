using Business.Interfaces.Services;
using Business.IO;
using Business.IO.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class CourseController : ControllerBase
    {
        private ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CourseInput _course)
        {
            try
            {
                return Ok(await _service.Save(_course));
            }
            catch (Exception ex)
            {
                return Ok(new ReturnView() { Object = ex.GetBaseException(), Message = "Internal error!", Status = false });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CourseInput _course)
        {
            try
            {
                return Ok(await _service.Edit(_course));
            }
            catch (Exception ex)
            {
                return Ok(new ReturnView() { Object = ex.GetBaseException(), Message = "Internal error!", Status = false });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnView() { Object = null, Message = ex.Message, Status = false });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _service.Get(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnView() { Object = null, Message = ex.Message, Status = false });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMany([FromQuery] CourseFilter _filter)
        {
            try
            {
                return Ok(await _service.GetMany(_filter));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnView() { Object = null, Message = ex.Message, Status = false });
            }
        }


    }
}
