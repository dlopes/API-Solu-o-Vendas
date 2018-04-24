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
    public class GrupoController : ApiController
    {
        // GET: api/Grupo
        public IEnumerable<Grupo> GetGrupos()
        {
            GrupoRepository grupoRepository = new GrupoRepository();
            var grupo = grupoRepository.Consultar();
            return grupo;
        }

        // GET: api/Grupo/5
        public IHttpActionResult GetGrupo(long id)
        {
            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");


            GrupoRepository grupoRepository = new GrupoRepository();

            Grupo Grupo = grupoRepository.RetornarPorId(id);
            if (Grupo == null)
            {
                return NotFound();
            }

            return Ok(Grupo);
        }

        // POST: api/Grupo
        // [BasicAuhtentication]
        public IHttpActionResult PostGrupo(Grupo Grupo)
        {
            //validador.ValidateAndThrow(funcioanario);

            GrupoRepository grupoRepository = new GrupoRepository();
            grupoRepository.Inserir(Grupo);

            return CreatedAtRoute("DefaultApi", new { id = Grupo.id }, Grupo);
        }

        // PUT: api/Grupo/5
        //[BasicAuhtentication]
        public IHttpActionResult PutGrupo(long id, Grupo Grupo)
        {
            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");

            if (id != Grupo.id)
                return BadRequest("O id informado na URL deve ser igual ao id informado no corpo da requisição.");

            GrupoRepository grupoRepository = new GrupoRepository();
            if (grupoRepository.RetornarCout(id) == 0)
                return NotFound();

            //validador.ValidateAndThrow(funcioanario);

            grupoRepository.Alterar(Grupo);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Grupo/5
        //[BasicAuhtentication]
        public IHttpActionResult DeleteGrupo(long id)
        {
            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");
            GrupoRepository grupoRepository = new GrupoRepository();
            Grupo Grupo = grupoRepository.RetornarPorId(id);

            if (Grupo == null)
                return NotFound();
            // if (/*empRepository.vagaCount(id) > 0*/ empresa.Vagas.Count > 0)
            //return Content(HttpStatusCode.Forbidden, "Essa empresa não pode ser excluída, pois há vagas ativas relacionadas a ela.");

            grupoRepository.Excluir(Grupo);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
