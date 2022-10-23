using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EsquemaPrueba.Models;
using EsquemaPrueba.Interfaces;

namespace EsquemaPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly PersonaInterface personaInterface;

        public PersonasController(PersonaInterface _personaInterface)
        {
            this.personaInterface = _personaInterface;
        }

        // GET: api/Personas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            return await personaInterface.GetPersonas();
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersona(int id)
        {
            var persona = await personaInterface.GetPersona(id);

            if (persona.Value == null)
            {
                return NotFound();
            }

            return persona;
        }

        // PUT: api/Personas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, Persona persona)
        {
            var res = await personaInterface.PutPersona(id, persona);

            if (res.Equals(1))
            {
                return BadRequest();
            }

            if (res.Equals(2))
            {
                return NotFound();
            }

            return Ok();

        }

        // POST: api/Personas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(Persona persona)
        {
            var res = await personaInterface.PostPersona(persona);

            if(res.Equals(1))
            {
                return CreatedAtAction("GetPersona", new { id = persona.IdPersona }, persona);
            }

            return BadRequest();
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var persona = await personaInterface.DeletePersona(id);
            if (persona.Equals(1))
            {
                return NotFound();
            }


            return Ok();
        }

        private bool PersonaExists(int id)
        {
            return personaInterface.PersonaExists(id);
        }
    }
}
