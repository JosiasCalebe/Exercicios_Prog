using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Sstop.WebApi.Domains;
using Senai.Sstop.WebApi.Repositories;

namespace Senai.Sstop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstilosController : ControllerBase
    {

        EstiloRepository estiloRepository = new EstiloRepository();
        [Produces("application/json")]
        [HttpGet]
        public IEnumerable<EstiloDomain> Listar()
        {
            return estiloRepository.Listar();
        }
        [Produces("application/json")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
        EstiloDomain Estilo = estiloRepository.BuscarPorId(id);
        if (Estilo == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Estilo);
            }
        }


        [HttpPost]
        public IActionResult Cadastrar(EstiloDomain estiloDomain)
        {
            estiloRepository.Cadastrar(estiloDomain);
            return Ok(estiloDomain);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(EstiloDomain estiloDomain, int id)
        {
            estiloRepository.Alterar(estiloDomain, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            estiloRepository.Deletar(id);
            return Ok();
        }
    }
}