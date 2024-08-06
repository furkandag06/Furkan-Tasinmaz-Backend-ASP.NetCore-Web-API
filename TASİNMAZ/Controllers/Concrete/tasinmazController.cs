using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TASİNMAZ.Business.Abstract.Interfaces;
using TASİNMAZ.Business.Concrete.Services;
using TASİNMAZ.Entities.Concrete;
using TASİNMAZ.Entities.Concrete.Models;

namespace TASİNMAZ.Controllers.Concrete
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasinmazController : ControllerBase
    {
        private readonly tasinmazInterface _tasinmazService;

        public TasinmazController(tasinmazInterface tasinmazService)
        {
            _tasinmazService = tasinmazService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _tasinmazService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tasinmaz = await _tasinmazService.GetByIdAsync(id);

            if (tasinmaz == null)
            {
                return NotFound();
            }

            return Ok(tasinmaz);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var tasinmazlar = await _tasinmazService.GetByUserIdAsync(userId);
            return Ok(tasinmazlar);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] tasinmaz tasinmaz)
        {
            var createdTasinmaz = await _tasinmazService.AddAsync(tasinmaz);
            return CreatedAtAction(nameof(GetById), new { id = createdTasinmaz.Id }, createdTasinmaz);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] tasinmaz tasinmaz)
        {
            var updatedTasinmaz = await _tasinmazService.UpdateAsync(id, tasinmaz);
            if (updatedTasinmaz == null)
            {
                return NotFound();
            }

            return Ok(updatedTasinmaz);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tasinmazService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}


