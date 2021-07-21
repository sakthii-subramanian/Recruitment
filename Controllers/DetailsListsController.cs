using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recruitment.Models;

namespace Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsListsController : ControllerBase
    {
        private readonly RecruitmentContext _context;

        public DetailsListsController(RecruitmentContext context)
        {
            _context = context;
        }

        // GET: api/DetailsLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailsList>>> GetDetailsLists()
        {
            return await _context.DetailsLists.ToListAsync();
        }

        // GET: api/DetailsLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetailsList>> GetDetailsList(long id)
        {
            var detailsList = await _context.DetailsLists.FindAsync(id);

            if (detailsList == null)
            {
                return NotFound();
            }

            return detailsList;
        }

        // PUT: api/DetailsLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetailsList(long id, DetailsList detailsList)
        {
            if (id != detailsList.Id)
            {
                return BadRequest();
            }

            _context.Entry(detailsList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailsListExists(id))
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

        // POST: api/DetailsLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetailsList>> PostDetailsList(DetailsList detailsList)
        {
            _context.DetailsLists.Add(detailsList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetailsList", new { id = detailsList.Id }, detailsList);
        }

        // DELETE: api/DetailsLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetailsList(long id)
        {
            var detailsList = await _context.DetailsLists.FindAsync(id);
            if (detailsList == null)
            {
                return NotFound();
            }

            _context.DetailsLists.Remove(detailsList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetailsListExists(long id)
        {
            return _context.DetailsLists.Any(e => e.Id == id);
        }
    }
}
