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
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioInterface usuarioInterface;

        public UsuariosController(UsuarioInterface _usuarioInterface)
        {
            this.usuarioInterface = _usuarioInterface;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await usuarioInterface.GetUsuarios();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario(int id)
        {
            var usuario = await usuarioInterface.GetUsuario(id);

            if (usuario.Value == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            var res = await usuarioInterface.PutUsuario(id, usuario);

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

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            var res = await usuarioInterface.PostUsuario(usuario);

            if (res.Equals(1))
            {
                return Ok(usuario);
            }

            return BadRequest();
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
             var usuario = await usuarioInterface.DeleteUsuario(id);
            if (usuario.Equals(1))
            {
                return NotFound();
            }


            return Ok();
        }

        private bool UsuarioExists(int id)
        {
            return usuarioInterface.UsuarioExists(id);
        }
    }
}
