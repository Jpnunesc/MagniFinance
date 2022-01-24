using Business.Interfaces.Services;
using Business.IO;
using Business.IO.Grade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class GradeController : ControllerBase
    {
        private IGradeService _service;

        public GradeController(IGradeService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GradeInput _grade)
        {
            try
            {
                return Ok(await _service.Save(_grade));
            }
            catch (Exception ex)
            {
                return Ok(new ReturnView() { Object = ex.GetBaseException(), Message = "Internal error!", Status = false });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] GradeInput _grade)
        {
            try
            {
                return Ok(await _service.Edit(_grade));
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
        public async Task<IActionResult> GetMany([FromQuery] GradeFilter _filter)
        {
            try
            {
                var el = await _service.GetMany(_filter);
                return Ok(el);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnView() { Object = null, Message = ex.Message, Status = false });
            }
        }


    }
}
