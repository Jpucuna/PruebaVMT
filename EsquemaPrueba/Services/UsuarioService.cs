using EsquemaPrueba.Interfaces;
using EsquemaPrueba.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EsquemaPrueba.Services
{
    public class UsuarioService : UsuarioInterface
    {
        private readonly dbContext _context;

        public UsuarioService(dbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            try
            {

                return await _context.Usuarios.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario(int id)
        {
            //USO DE LINQ
            var usuario = await (from _usuario in _context.Usuarios
                           where _usuario.IdUsuario == id
                           select new Usuario
                           {
                               IdUsuario = _usuario.IdUsuario,
                               IdPersona = _usuario.IdPersona,
                               Usuario1 = _usuario.Usuario1,
                               Clave = _usuario.Clave,
                               Estado = _usuario.Estado
                           }).ToListAsync();
            return usuario;
        }


        public async Task<int> PutUsuario(int id, Usuario usuario)
        {
            int band = 0;
            if (id != usuario.IdUsuario)
            {
                return 1;
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return 2;
                }
                else
                {
                    throw;
                }
            }

            return band;
        }


        public async Task<int> PostUsuario(Usuario usuario)
        {

            try
            {
                var usu = _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task<int> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return 1;
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return 0;
        }


        public bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }

    }
}
