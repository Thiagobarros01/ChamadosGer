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
        public async Task<ActionResult> GetChamados()
        {
            var chamados = await _chamadoService.ObterTodosChamadosAsync();
            return Ok(chamados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetChamado(int id)
        {
            var chamado = await _chamadoService.ObterChamadoPorIdAsync(id);
            if (chamado == null)
                return NotFound();
            return Ok(chamado);
        }

        [HttpPost]
        public async Task<ActionResult> CreateChamado([FromBody] ChamadoDto chamadoDto)
        {
            var chamado = await _chamadoService.CriarChamadoAsync(chamadoDto);
            return CreatedAtAction(nameof(GetChamado), new { id = chamado.Id }, chamado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateChamado(int id, [FromBody] ChamadoDto chamadoDto)
        {
            if (id != chamadoDto.Id)
                return BadRequest();

            var chamadoAtualizado = await _chamadoService.AtualizarChamadoAsync(id, chamadoDto);
            if (chamadoAtualizado == null)
                return NotFound();

            return Ok(chamadoAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteChamado(int id)
        {
            var sucesso = await _chamadoService.DeletarChamadoAsync(id);
            if (!sucesso)
                return NotFound();

            return NoContent();
        }
    }
}

