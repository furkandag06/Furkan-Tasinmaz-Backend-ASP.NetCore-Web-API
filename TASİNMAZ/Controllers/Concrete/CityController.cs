using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TASİNMAZ.Business.Abstract.Interfaces;
using TASİNMAZ.Entities.Concrete;

namespace TASİNMAZ.Controllers.Concrete
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityInterface _city;

        public CityController(CityInterface city)
        {
            _city = city;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _city.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var city = await _city.GetByIdAsync(id);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }
    }
}
