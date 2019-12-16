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
    public class AvaliacaoSugestaoController : Controller
    {
        private ServiceAvaliacaoSugestao service = new ServiceAvaliacaoSugestao();


        [HttpGet]
        public IEnumerable<AvaliacaoSugestao> Get()
        {
            return service.SelectAll();
        }

        [HttpPost]
        public IActionResult Post([FromBody] AvaliacaoSugestao avaliacaoSugestao)
        {
            try
            {
                service.Insert<AvaliacaoSugestaoValidator>(avaliacaoSugestao);
                return Ok("Avaliação cadastrado com sucesso");
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
        public IActionResult Put([FromBody] AvaliacaoSugestao avaliacaoSugestao)
        {
            try
            {
                avaliacaoSugestao.AvaliacaoID= service.SelectAll()
                    .Where(f => (f.AvaliacaoID == avaliacaoSugestao.AvaliacaoID))
                    .FirstOrDefault().AvaliacaoID;

                service.Update<AvaliacaoSugestaoValidator>(avaliacaoSugestao);
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