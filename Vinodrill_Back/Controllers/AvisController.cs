﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.EntityFramework;

namespace Vinodrill_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvisController : ControllerBase
    {
        private readonly VinodrillDBContext _context;

        public AvisController(VinodrillDBContext context)
        {
            _context = context;
        }

        // GET: api/Avis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Avis>>> GetAvis()
        {
            return await _context.Avis.ToListAsync();
        }

        // GET: api/Avis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Avis>> GetAvis(int id)
        {
            var avis = await _context.Avis.FindAsync(id);

            if (avis == null)
            {
                return NotFound();
            }

            return avis;
        }

        // PUT: api/Avis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvis(int id, Avis avis)
        {
            if (id != avis.IdAvis)
            {
                return BadRequest();
            }

            _context.Entry(avis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvisExists(id))
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

        // POST: api/Avis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Avis>> PostAvis(Avis avis)
        {
            _context.Avis.Add(avis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvis", new { id = avis.IdAvis }, avis);
        }

        // DELETE: api/Avis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvis(int id)
        {
            var avis = await _context.Avis.FindAsync(id);
            if (avis == null)
            {
                return NotFound();
            }

            _context.Avis.Remove(avis);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AvisExists(int id)
        {
            return _context.Avis.Any(e => e.IdAvis == id);
        }
    }
}
