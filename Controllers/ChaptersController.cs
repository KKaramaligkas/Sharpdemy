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
    public class ChaptersController : ControllerBase
    {
        private readonly SharpdemyContext _context;

        public ChaptersController(SharpdemyContext context)
        {
            _context = context;
        }

        // GET: api/Chapters
        [HttpGet]
        public IEnumerable<Chapter> GetChapter()
        {
            return _context.Chapter;
        }

        // GET: api/Chapters/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChapter([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chapter = await _context.Chapter.FindAsync(id);

            if (chapter == null)
            {
                return NotFound();
            }

            return Ok(chapter);
        }

        // PUT: api/Chapters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChapter([FromRoute] int id, [FromBody] Chapter chapter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chapter.ChapterId)
            {
                return BadRequest();
            }

            _context.Entry(chapter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChapterExists(id))
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

        // POST: api/Chapters
        [HttpPost]
        public async Task<IActionResult> PostChapter([FromBody] Chapter chapter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Chapter.Add(chapter);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChapterExists(chapter.ChapterId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChapter", new { id = chapter.ChapterId }, chapter);
        }

        // DELETE: api/Chapters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChapter([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chapter = await _context.Chapter.FindAsync(id);
            if (chapter == null)
            {
                return NotFound();
            }

            _context.Chapter.Remove(chapter);
            await _context.SaveChangesAsync();

            return Ok(chapter);
        }

        private bool ChapterExists(int id)
        {
            return _context.Chapter.Any(e => e.ChapterId == id);
        }
    }
}