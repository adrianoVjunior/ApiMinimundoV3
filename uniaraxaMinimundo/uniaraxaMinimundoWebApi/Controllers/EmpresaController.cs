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
    public class EmpresaController : Controller
    {
        private ServiceEmpresa service = new ServiceEmpresa();


        [HttpGet]
        public IEnumerable<Empresa> Get()
        {
            return service.SelectAll();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Empresa empresa)
        {
            try
            {
                service.Insert<EmpresaValidator>(empresa);
                return Ok("Empresa cadastrada com sucesso");
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

        //problema
        [HttpPut]
        public IActionResult Put([FromBody] Empresa empresa)
        {
            try
            {
                empresa.EmpresaID = service.SelectAll().Where(f => (f.CNPJ == empresa.CNPJ)).FirstOrDefault().EmpresaID;
                service.Update<EmpresaValidator>(empresa);
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