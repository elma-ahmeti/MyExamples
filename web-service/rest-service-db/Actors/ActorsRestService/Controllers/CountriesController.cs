using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ActorsRestService.Data;
using ActorsRestService.Models;

namespace CountriesRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ActorsRestServiceContext _context;

        public CountriesController(ActorsRestServiceContext context)
        {
            _context = context;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            return await _context.Country.ToListAsync();
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountries(long id)
        {
            var Country = await _context.Country.FindAsync(id);

            if (Country == null)
            {
                return NotFound();
            }

            return Country;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(long id, Country Country)
        {
            if (id != Country.CountryId)
            {
                return BadRequest();
            }

            _context.Entry(Country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActorExists(id))
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

        // POST: api/Country
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostActor(Country Country)
        {
            _context.Actor.Add(Country);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { ActorId = Country.ActorId }, Country);
        }

        // DELETE: api/Country/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(long id)
        {
            var Country = await _context.Actor.FindAsync(id);
            if (Country == null)
            {
                return NotFound();
            }

            _context.Country.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(long id)
        {
            return _context.Country.Any(e => e.ActorId == id);
        }
    }
}
