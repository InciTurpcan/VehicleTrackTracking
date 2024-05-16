using Domain.DataTransferObjects;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Vechicle_Track_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public PartsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAlllParts()
        {
            try
            {
                var books = _manager.Part.GetAllParts(false);
                return Ok(books);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpGet("{id:int}")]
        public IActionResult GetOnePart([FromRoute(Name = "id")] int id)
        {
            try
            {
                var part = _manager.Part.GetOnePartById(id, false);

                if (part is null)
                    return NotFound();
                return Ok(part);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult CreateOnePart([FromBody] PartDtoForInsertion partDto)
        {
            try
            {
                if (partDto is null)
                    return BadRequest();

                _manager.Part.CreateOnePart(partDto);

                return StatusCode(201, partDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOnePart([FromBody] PartDtoForUpdate partDto, [FromRoute(Name = "id")] int id)
        {
            try
            {
                if (partDto is null)
                    return BadRequest();

                _manager.Part.UpdateOnePart(id, partDto, false);
                return NoContent();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOnePart([FromRoute(Name = "id")] int id)
        {
            try
            {
                _manager.Part.DeleteOnePart(id, false);
                return NoContent();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
