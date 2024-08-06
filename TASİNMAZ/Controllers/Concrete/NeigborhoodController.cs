using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASİNMAZ.Business.Abstract.Interfaces;
using TASİNMAZ.Entities.Concrete;

namespace TASİNMAZ.Controllers.Concrete
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeighborhoodController : ControllerBase
    {
        private readonly NeigborhoodInterface _neighborhoodService;

        public NeighborhoodController(NeigborhoodInterface neighborhoodService)
        {
            _neighborhoodService = neighborhoodService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _neighborhoodService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var neighborhood = await _neighborhoodService.GetByIdAsync(id);

            if (neighborhood == null)
            {
                return NotFound();
            }

            return Ok(neighborhood);
        }

        // Yeni metod
        [HttpGet("by-district/{districtId}")]
        public async Task<IActionResult> GetByDistrictId(int districtId)
        {
            var neighborhoods = await _neighborhoodService.GetByDistrictIdAsync(districtId);

            if (neighborhoods == null || !neighborhoods.Any())
            {
                return NotFound();
            }

            return Ok(neighborhoods);
        }
    }
}


