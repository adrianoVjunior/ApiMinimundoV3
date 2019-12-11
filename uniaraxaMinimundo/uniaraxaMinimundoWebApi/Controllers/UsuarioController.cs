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
    public class UsuarioController : Controller
    {
        private ServiceUsuario service = new ServiceUsuario();


        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return service.SelectAll();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                service.Insert<UsuarioValidator>(usuario);
                return Ok("Usuário cadastrado com sucesso");
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
        public IActionResult Put([FromBody] Usuario usuario)
        {
            try
            {
                usuario.UsuarioID = service.SelectAll().Where(f => (f.CPF == usuario.CPF)).FirstOrDefault().UsuarioID;
                service.Update<UsuarioValidator>(usuario);
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