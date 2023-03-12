using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SejourController : ControllerBase
    {
        private readonly ISejourRepository dataRepository;

        public SejourController(ISejourRepository dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Avis
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Avis>))]
        public async Task<ActionResult<IEnumerable<Sejour>>> GetSejours([FromQuery] string? idstheme = "")
        {
            if (idstheme != "")
            {
                var reponse = await dataRepository.GetAllFromSpecificTheme(idstheme);

                if (reponse == null)
                {
                    return BadRequest($"'{idstheme}' is not a valid parameter, use comma separated integer instead (like 1,2,3)");
                }

                return reponse;
            }
            return await dataRepository.GetAll();
        }

        // // GET: api/Avis/GetAvisById/5
        // [HttpGet("GetAvisById/{id}")]
        // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Avis))]
        // [ProducesResponseType(StatusCodes.Status404NotFound)]
        // public async Task<ActionResult<Avis>> GetAvisById(int id, [FromQuery] bool includeSejour = false)
        // {
        //     // initialisation de la variable qui va contenir l'avis à retourner, null par défaut, de type inconu
        //     ActionResult<Avis>? avi;
            
        //     if (includeSejour) 
        //     {
        //         avi = await dataRepository.GetByIdWithSejour(id);
        //     } else {
        //         avi = await dataRepository.GetById(id);
        //     }

        //     if (avi == null)
        //     {
        //         return NotFound();
        //     }

        //     return avi;

        //     // return StatusCode(StatusCodes.Status405MethodNotAllowed);
        // }

        // //PUT: api/Avis/5
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // [ProducesResponseType(StatusCodes.Status204NoContent)]
        // [ProducesResponseType(StatusCodes.Status404NotFound)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<IActionResult> PutAdresse(int id, Avis avi)
        // {

        //     if (id != avi.IdAvis)
        //     {
        //         return BadRequest();
        //     }

        //     var userToUpdate = await dataRepository.GetById(id);
        //     if (userToUpdate == null)
        //     {
        //         return NotFound();
        //     }
        //     else
        //     {
        //         await dataRepository.Update(userToUpdate.Value, avi);
        //         return NoContent();
        //     }
        // }

        // // POST: api/Avis
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Avis))]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<ActionResult<Avis>> PostAdresse(Avis avi)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }
        //     await dataRepository.Add(avi);

        //     return CreatedAtAction("GetAvisById", new { id = avi.IdAvis }, avi);
        // }

        // // DELETE: api/Avis/5
        // [HttpDelete("{id}")]
        // [ProducesResponseType(StatusCodes.Status204NoContent)]
        // [ProducesResponseType(StatusCodes.Status404NotFound)]
        // public async Task<IActionResult> DeleteAvis(int id)
        // {
        //     var avi = await dataRepository.GetById(id);
        //     if (avi == null)
        //     {
        //         return NotFound();
        //     }            

        //     await dataRepository.Delete(avi.Value);

        //     return NoContent();
        // }
    }
}
