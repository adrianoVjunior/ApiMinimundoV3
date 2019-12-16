using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uniaraxaMinimundo.Dominio.Entidades;
using uniaraxaMinimundo.Servico;
using uniaraxaMinimundo.Servico.Validators;

namespace uniaraxaMinimundoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class AvaliadorController : Controller
    {
        private ServiceAvaliador service = new ServiceAvaliador();


        [HttpGet]
        public IEnumerable<Avaliador> Get()
        {
            return service.SelectAll();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Avaliador avaliador)
        {
            try
            {
                service.Insert<AvaliadorValidator>(avaliador);
                return Ok("Funcionario cadastrado com sucesso");
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //problema: Não conseguimos realizar a join entre as tabelas utilizando o EF
        [HttpPut]
        public IActionResult Put([FromBody] Avaliador avaliador)
        {
            try
            {
                avaliador.AvaliadorID = service.SelectAll()
                    .Where(f => (f.UsuarioID == avaliador.UsuarioID))
                    .FirstOrDefault().AvaliadorID;

                service.Update<AvaliadorValidator>(avaliador);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}