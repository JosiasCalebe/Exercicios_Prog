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
    [Produces("application/json")]
    [ApiController]
    public class ArtistasController : ControllerBase
    {
        ArtistaRepository artistaRepository = new ArtistaRepository();
        /// <summary>
        /// Listar todos os artistas.
        /// </summary>
        /// <returns>Lista de artistas</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(artistaRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(ArtistaDomain artista)
        {
            try
            {
                artistaRepository.Cadastrar(artista);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new { mensagem = "ocorreu um erro." + ex.Message});
            }
        }

    }
}