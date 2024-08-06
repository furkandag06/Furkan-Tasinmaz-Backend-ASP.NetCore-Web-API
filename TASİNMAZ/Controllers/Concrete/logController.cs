using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TASİNMAZ.Business.Abstract.Interfaces;
using TASİNMAZ.Entities.Concrete.Models;

namespace TASİNMAZ.Controllers.Concrete
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly logInterface _service;

        public LogController(logInterface service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Log>>> GetAllLog()
        {
            var logs = await _service.ListLog();
            return Ok(logs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Log>> GetLogById(int id)
        {
            var log = await _service.GetLogById(id);
            if (log == null)
            {
                return NotFound();
            }
            return log;
        }

        [HttpPost]
        public async Task<ActionResult<Log>> AddLog(Log log)
        {
            await _service.AddLog(log);
            return CreatedAtAction(nameof(GetLogById), new { id = log.Id }, log);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLog(int id, Log log)
        {
            if (id != log.Id)
            {
                return BadRequest();
            }

            await _service.UpdateLog(log);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLog(int id)
        {
            await _service.DeleteLog(id);
            return NoContent();
        }



        [HttpGet("search")]
        public async Task<IActionResult> SearchLogs(string term)
        {
            var logs = await _service.SearchLogsAsync(term);
            return Ok(logs);
        }
    }
}
