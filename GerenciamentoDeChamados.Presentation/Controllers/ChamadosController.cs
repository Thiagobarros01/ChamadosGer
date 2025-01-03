using GerenciamentoDeChamados.Application.DTOs;
using GerenciamentoDeChamados.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeChamados.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChamadosController : ControllerBase
    {
        private readonly IChamadoService _chamadoService;

        public ChamadosController(IChamadoService chamadoService)
        {
            _chamadoService = chamadoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChamadoDto>>> GetChamados()
        {
            var chamados = await _chamadoService.ObterChamadosAsync();
            return Ok(chamados);
        }

        [HttpPost]
        public async Task<ActionResult> PostChamado(ChamadoDto chamadoDto)
        {
            var chamado = await _chamadoService.CriarChamadoAsync(chamadoDto);
            return CreatedAtAction(nameof(GetChamados), new { id = chamado.Id }, chamado);
        }
    }
}

