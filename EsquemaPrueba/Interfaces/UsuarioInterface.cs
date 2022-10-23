using EsquemaPrueba.Models;
using Microsoft.AspNetCore.Mvc;

namespace EsquemaPrueba.Interfaces
{
    public interface UsuarioInterface
    {
        Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios();
        Task<ActionResult<IEnumerable<Usuario>>> GetUsuario(int id);
        Task<int> PutUsuario(int id, Usuario usuario);
        Task<int> PostUsuario(Usuario usuario);
        Task<int> DeleteUsuario(int id);
        bool UsuarioExists(int id);
    }
}
