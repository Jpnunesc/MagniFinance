using Business.Interfaces.Services;
using Business.IO;
using Business.IO.Teacher;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class TeacherController : ControllerBase
    {
        private ITeacherService _service;

        public TeacherController(ITeacherService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TeacherInput _theacher)
        {
            try
            {
                return Ok(await _service.Save(_theacher));
            }
            catch (Exception ex)
            {
                return Ok(new ReturnView() { Object = ex.GetBaseException(), Message = "Internal error!", Status = false });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TeacherInput _theacher)
        {
            try
            {
                return Ok(await _service.Edit(_theacher));
            }
            catch (Exception ex)
            {
                return Ok(new ReturnView() { Object = ex.GetBaseException(), Message = "Internal error!", Status = false });
            }
        }

        [HttpDelete()]
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
        public async Task<IActionResult> GetMany([FromQuery] TeacherFilter _filter)
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
