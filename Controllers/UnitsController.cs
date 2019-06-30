using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecourse.Models;

namespace Ecourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly SharpdemyContext _context;

        public UnitsController(SharpdemyContext context)
        {
            _context = context;
        }

        // GET: api/Units
        [HttpGet]
        public IEnumerable<Units> GetUnits()
        {
            return _context.Units;
        }

        // GET: api/Units/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUnits([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var units = await _context.Units.FindAsync(id);

            if (units == null)
            {
                return NotFound();
            }

            return Ok(units);
        }

        // PUT: api/Units/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnits([FromRoute] int id, [FromBody] Units units)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != units.UnitId)
            {
                return BadRequest();
            }

            _context.Entry(units).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitsExists(id))
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

        // POST: api/Units
        [HttpPost]
        public async Task<IActionResult> PostUnits([FromBody] Units units)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Units.Add(units);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UnitsExists(units.UnitId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUnits", new { id = units.UnitId }, units);
        }

        // DELETE: api/Units/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnits([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var units = await _context.Units.FindAsync(id);
            if (units == null)
            {
                return NotFound();
            }

            _context.Units.Remove(units);
            await _context.SaveChangesAsync();

            return Ok(units);
        }

        private bool UnitsExists(int id)
        {
            return _context.Units.Any(e => e.UnitId == id);
        }
    }
}