using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ErrorCenter.Data;
using ErrorCenter.Models;

namespace ErrorCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        private readonly ErrorCenterContext _context;

        public ErrorsController(ErrorCenterContext context)
        {
            _context = context;
        }

        // GET: api/Errors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Error>>> GetError()
        {
            return await _context.Error.ToListAsync();
        }

        // GET: api/Movies/searchString
        [HttpGet("{searchString}")]
        public async Task<ActionResult<IEnumerable<Error>>> SearchErrorDescription(string searchString)
        {
            var errors = from e in _context.Error
                         select e;
            if (!String.IsNullOrEmpty(searchString))
            {
                errors = errors.Where(s => s.Description.Contains(searchString));
            }

            return await errors.ToListAsync();
        }

        [HttpGet("searchbylevel/{levelType}")]
        public async Task<ActionResult<IEnumerable<Error>>> SearchByLevel(string levelType)
        {
            var errors = from e in _context.Error
                         select e;
            if (!String.IsNullOrEmpty(levelType))

            {
                if(levelType == "Error" || levelType == "Warning" 
                    || levelType == "Debug")
                {
                    errors = errors.Where(s => s.Level == levelType);
                }
               
            }

            return await errors.ToListAsync();
        }

        [HttpGet("ordererror/{orderType}")]
        public async Task<ActionResult<IEnumerable<Error>>> OrderErrorByEventsCount(string orderType)
        {
            var errors = from e in _context.Error
                         select e;
            if (!String.IsNullOrEmpty(orderType))
            {
                if (orderType == "DESC")
                {
                    errors = from e in errors
                             orderby e.EventsCount descending
                             select e;
                }
                else if (orderType == "ASC")
                {
                    errors = from e in errors
                             orderby e.EventsCount ascending
                             select e;

                }


            }
            return await errors.ToListAsync();
        }

        // GET: api/Errors/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Error>> GetError(int id)
        {
            var error = await _context.Error.FindAsync(id);

            if (error == null)
            {
                return NotFound();
            }

            return error;
        }

        // PUT: api/Errors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutError(int id, Error error)
        {
            if (id != error.Id)
            {
                return BadRequest();
            }

            _context.Entry(error).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ErrorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Errors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Error>> PostError(Error error)
        {
            _context.Error.Add(error);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetError", new { id = error.Id }, error);
        }

        // DELETE: api/Errors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteError(int id)
        {
            var error = await _context.Error.FindAsync(id);
            if (error == null)
            {
                return NotFound();
            }

            _context.Error.Remove(error);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ErrorExists(int id)
        {
            return _context.Error.Any(e => e.Id == id);
        }
    }
}
