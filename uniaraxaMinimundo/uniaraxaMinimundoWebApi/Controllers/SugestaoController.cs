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
    public class SugestaoController : Controller
    {
        private ServiceSugestao service = new ServiceSugestao();


        [HttpGet]
        public IEnumerable<Sugestao> Get()
        {
            return service.SelectAll();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Sugestao sugestao)
        {
            try
            {
                service.Insert<SugestaoValidator>(sugestao);
                return Ok("Sugestao cadastrado com sucesso");
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
        public IActionResult Put([FromBody] Sugestao sugestao)
        {
            try
            {
                sugestao.SugestaoID= service.SelectAll()
                    .Where(f => (f.SugestaoID == sugestao.SugestaoID))
                    .FirstOrDefault().SugestaoID;

                service.Update<SugestaoValidator>(sugestao);
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