using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("city")]
    public class CityController : Controller
    {
        private readonly ICityRepository _repository;
        public CityController(ICityRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            try
            {
                return Ok(_repository.GetCities());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public IActionResult PostCity([FromBody] City city)
        {
            return Created("", _repository.AddCity(city));
        }

        [HttpPut]
        public IActionResult PutCity([FromBody] City city)
        {
            try
            {
                var updatedCity = _repository.UpdateCity(city);
                return Ok(updatedCity);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}