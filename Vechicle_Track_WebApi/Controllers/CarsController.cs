using Domain.DataTransferObjects;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net.Http.Json;
using System.Xml;
using Newtonsoft.Json;

namespace Vechicle_Track_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CarsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAlllCars()
        {
            try
            {
                var cars = _manager.Car.GetAllCars(false);
                return Ok(cars);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
       

        [HttpGet("{id:int}")]
        public IActionResult GetOneCar([FromRoute(Name = "id")] int id)
        {
            try
            {
                var car = _manager.Car.GetOneCarById(id, false);

                if (car is null)
                    return NotFound();
                return Ok(car);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        [HttpGet("GetOneCarWithParts/{id:int}")]
        public IActionResult GetOneCarWithParts([FromRoute(Name = "id")] int id)
        {
           

            var car = _manager.Car.GetOneCarWithPartsById(id);

            var json = JsonConvert.SerializeObject(car, Newtonsoft.Json.Formatting.Indented);

            return Ok(json);

        }

        [HttpPost]
        public IActionResult CreateOneCar([FromBody] CarDtoForInsertion carDto)
        {
            try
            {
                if (carDto is null)
                    return BadRequest();

                _manager.Car.CreateOneCar(carDto);

                return StatusCode(201, carDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneCar([FromBody] CarDtoForUpdate carDto, [FromRoute(Name = "id")] int id)
        {
            try
            {
                if (carDto is null)
                    return BadRequest();

                _manager.Car.UpdateOneCar(id, carDto, false);
                return NoContent();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneCar([FromRoute(Name = "id")] int id)
        {
            try
            {
                _manager.Car.DeleteOneCar(id, false);
                return NoContent();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
