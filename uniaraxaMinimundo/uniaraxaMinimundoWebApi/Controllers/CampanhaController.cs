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
    public class CampanhaController : Controller
    {
        private ServiceCampanha service = new ServiceCampanha();


        [HttpGet]
        public IEnumerable<Campanha> Get()
        {
            return service.SelectAll();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Campanha campanha)
        {
            try
            {
                service.Insert<CampanhaValidator>(campanha);
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
        public IActionResult Put([FromBody] Campanha campanha)
        {
            try
            {
                campanha.CampanhaID = service.SelectAll()
                    .Where(f => (f.AvaliadorID == campanha.AvaliadorID && f.EmpresaID == campanha.EmpresaID))
                    .FirstOrDefault().CampanhaID;

                service.Update<CampanhaValidator>(campanha);
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