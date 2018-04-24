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
    public class FuncionarioController : ApiController
    {
        // GET: api/Funcionario
        public IEnumerable<Funcionario> GetFuncionarios()
        {
            FuncionarioRepository funcRepository = new FuncionarioRepository();
            var funcionarios = funcRepository.Consultar();
            return funcionarios;
        }

        // GET: api/Funcionario/5
        public IHttpActionResult GetFuncionario(long id)
        {
            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");


            FuncionarioRepository funcRepository = new FuncionarioRepository();

            Funcionario funcionario = funcRepository.RetornarPorId(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return Ok(funcionario);
        }

        // POST: api/Funcionario
       // [BasicAuhtentication]
        public IHttpActionResult PostFuncionario(Funcionario funcioanario)
        {
            //validador.ValidateAndThrow(funcioanario);

            FuncionarioRepository funcRepository = new FuncionarioRepository();
            funcRepository.Inserir(funcioanario);

            return CreatedAtRoute("DefaultApi", new { id = funcioanario.id }, funcioanario);
        }

        // PUT: api/Funcionario/5
        //[BasicAuhtentication]
        public IHttpActionResult PutFuncionario(long id, Funcionario funcioanario)
        {
            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");

            if (id != funcioanario.id)
                return BadRequest("O id informado na URL deve ser igual ao id informado no corpo da requisição.");

            FuncionarioRepository funcRepository = new FuncionarioRepository();
            if (funcRepository.funcionarioCout(id) == 0)
                return NotFound();

            //validador.ValidateAndThrow(funcioanario);

            funcRepository.Alterar(funcioanario);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Funcionario/5
        //[BasicAuhtentication]
        public IHttpActionResult DeleteFuncionario(long id)
        {
            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");
            FuncionarioRepository funcRepository = new FuncionarioRepository();
            Funcionario funcionario = funcRepository.RetornarPorId(id);

            if (funcionario == null)
                return NotFound();
            // if (/*empRepository.vagaCount(id) > 0*/ empresa.Vagas.Count > 0)
            //return Content(HttpStatusCode.Forbidden, "Essa empresa não pode ser excluída, pois há vagas ativas relacionadas a ela.");

            funcRepository.Excluir(funcionario);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
