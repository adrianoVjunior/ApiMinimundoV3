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
    public class FuncionarioController : Controller
    {
        private ServiceFuncionario service = new ServiceFuncionario();


        [HttpGet]
        public IEnumerable<Funcionario> Get()
        {
            return service.SelectAll();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Funcionario funcionario)
        {
            try
            {
                service.Insert<FuncionarioValidator>(funcionario);
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
        public IActionResult Put([FromBody] Funcionario funcionario)
        {
            try
            {
                funcionario.FuncionarioID = service.SelectAll()
                    .Where(f => (f.UsuarioID == funcionario.UsuarioID && f.EmpresaID == funcionario.EmpresaID))
                    .FirstOrDefault().EmpresaID;
                service.Update<FuncionarioValidator>(funcionario);
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