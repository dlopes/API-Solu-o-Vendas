using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VendasAPI.Models.Entities;
using VendasAPI.Repository;

namespace VendasAPI.Controllers
{
    public class UsuariosController : ApiController
    {
        // GET: api/Usuarios
        public IEnumerable<Usuario> GetUsuarios()
        {
            UsuarioRepository userRepository = new UsuarioRepository();
            var usuarios = userRepository.Consultar();
            return usuarios;
        }

        // GET: api/Usuarios/5
        public IHttpActionResult GetUsuario(long id)
        {
            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");


            UsuarioRepository userRepository = new UsuarioRepository();

            Usuario usuario = userRepository.RetornarPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // POST: api/Usuarios
        // [BasicAuhtentication]
        public IHttpActionResult PostUsuarios(Usuario usuario)
        {
            //validador.ValidateAndThrow(funcioanario);

            UsuarioRepository userRepository = new UsuarioRepository();
            userRepository.Inserir(usuario);

            return CreatedAtRoute("DefaultApi", new { id = usuario.id }, usuario);
        }

        // PUT: api/Usuarios/5
        //[BasicAuhtentication]
        public IHttpActionResult PutUsuarios(long id, Usuario usuario)
        {
            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");

            if (id != usuario.id)
                return BadRequest("O id informado na URL deve ser igual ao id informado no corpo da requisição.");

            UsuarioRepository userRepository = new UsuarioRepository();
            if (userRepository.UsuariosCout(id) == 0)
                return NotFound();

            //validador.ValidateAndThrow(funcioanario);

            userRepository.Alterar(usuario);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Usuarios/5
        //[BasicAuhtentication]
        public IHttpActionResult DeleteUsuarios(long id)
        {
            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");
            UsuarioRepository userRepository = new UsuarioRepository();
            Usuario usuario = userRepository.RetornarPorId(id);

            if (usuario == null)
                return NotFound();
            // if (/*empRepository.vagaCount(id) > 0*/ empresa.Vagas.Count > 0)
            //return Content(HttpStatusCode.Forbidden, "Essa empresa não pode ser excluída, pois há vagas ativas relacionadas a ela.");

            userRepository.Excluir(usuario);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
