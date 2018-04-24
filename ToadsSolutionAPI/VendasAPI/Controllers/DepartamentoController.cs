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
    public class DepartamentoController : ApiController
    {
        // GET: api/Departamento
        public IEnumerable<Departamento> GetDepartamentos()
        {
            DepartamentoRepository departamentoRepository = new DepartamentoRepository();
            var departamento = departamentoRepository.Consultar();
            return departamento;
        }

        // GET: api/Departamento/5
        public IHttpActionResult GetDepartamento(long id)
        {
            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");


            DepartamentoRepository departamentoRepository = new DepartamentoRepository();

            Departamento departamento = departamentoRepository.RetornarPorId(id);
            if (departamento == null)
            {
                return NotFound();
            }

            return Ok(departamento);
        }

        // POST: api/Departamento
        // [BasicAuhtentication]
        public IHttpActionResult PostDepartamento(Departamento departamento)
        {
            //validador.ValidateAndThrow(funcioanario);

            DepartamentoRepository departamentoRepository = new DepartamentoRepository();
            departamentoRepository.Inserir(departamento);

            return CreatedAtRoute("DefaultApi", new { id = departamento.id }, departamento);
        }

        // PUT: api/Departamento/5
        //[BasicAuhtentication]
        public IHttpActionResult PutDepartamento(long id, Departamento departamento)
        {
            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");

            if (id != departamento.id)
                return BadRequest("O id informado na URL deve ser igual ao id informado no corpo da requisição.");

            DepartamentoRepository departamentoRepository = new DepartamentoRepository();
            if (departamentoRepository.RetornarCout(id) == 0)
                return NotFound();

            //validador.ValidateAndThrow(funcioanario);

            departamentoRepository.Alterar(departamento);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Departamento/5
        //[BasicAuhtentication]
        public IHttpActionResult DeleteDepartamento(long id)
        {
            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");
            DepartamentoRepository departamentoRepository = new DepartamentoRepository();
            Departamento departamento = departamentoRepository.RetornarPorId(id);

            if (departamento == null)
                return NotFound();
            // if (/*empRepository.vagaCount(id) > 0*/ empresa.Vagas.Count > 0)
            //return Content(HttpStatusCode.Forbidden, "Essa empresa não pode ser excluída, pois há vagas ativas relacionadas a ela.");

            departamentoRepository.Excluir(departamento);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
