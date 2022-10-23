using EsquemaPrueba.Models;
using Microsoft.AspNetCore.Mvc;

namespace EsquemaPrueba.Interfaces
{
    public interface PersonaInterface
    {
        Task<ActionResult<IEnumerable<Persona>>> GetPersonas();
        Task<ActionResult<IEnumerable<Persona>>> GetPersona(int id);
        Task<int> PutPersona(int id, Persona persona);
        Task<int> PostPersona(Persona persona);
        Task<int> DeletePersona(int id);
        bool PersonaExists(int id);
    }
}
