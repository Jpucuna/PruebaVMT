using EsquemaPrueba.Interfaces;
using EsquemaPrueba.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EsquemaPrueba.Services
{
    public class PersonaService: PersonaInterface
    {
        private readonly dbContext _context;

        public PersonaService(dbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            try
            {

                return await _context.Personas.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            return persona;
        }


        public async Task<int> PutPersona(int id, Persona persona)
        {
            int error = 0;
            if (id != persona.IdPersona)
            {
                return 1;
            }

            _context.Entry(persona).State = EntityState.Modified;

            try
            {
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
                {
                    return 2;
                }
                else
                {
                    throw;
                }
            }

            return error;
        }


        public async Task<int> PostPersona(Persona persona)
        {
            
            try
            {
                var pers = _context.Personas.Add(persona);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<int> DeletePersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return 1;
            }

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();

            return 0;
        }


        public bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.IdPersona == id);
        }
    }
}
