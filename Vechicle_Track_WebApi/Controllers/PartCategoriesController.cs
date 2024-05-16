using Domain.DataTransferObjects;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Vechicle_Track_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartCategoriesController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public PartCategoriesController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAlllCategories()
        {
            try
            {
                var books = _manager.PartCategory.GetAllPartCategories(false);
                return Ok(books);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneCategory([FromRoute(Name = "id")] int id)
        {
            try
            {
                var part = _manager.PartCategory.GetOnePartCategoryById(id, false);

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
        public IActionResult CreateOnePartCategory([FromBody] PartCategoryDtoForInsertion partDto)
        {
            try
            {
                if (partDto is null)
                    return BadRequest();

                _manager.PartCategory.CreateOnePartCategory(partDto);

                return StatusCode(201, partDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOnePartCategory([FromBody] PartCategoryDtoForUpdate partDto, [FromRoute(Name = "id")] int id)
        {
            try
            {
                if (partDto is null)
                    return BadRequest();

                _manager.PartCategory.UpdateOnePartCategory(id, partDto, false);
                return NoContent();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOnePartCategory([FromRoute(Name = "id")] int id)
        {
            try
            {
                _manager.PartCategory.DeleteOnePartCategory(id, false);
                return NoContent();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
