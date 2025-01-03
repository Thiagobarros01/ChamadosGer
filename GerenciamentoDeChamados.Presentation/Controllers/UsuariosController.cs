using GerenciamentoDeChamados.Application.DTOs;
using GerenciamentoDeChamados.Application.Interfaces;
using GerenciamentoDeChamados.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeChamados.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> GetUsuario(Guid id)
        {
            var usuario = await _usuarioService.ObterUsuarioPorIdAsync(id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> PostUsuario(UsuarioDto usuarioDto)
        {
            var usuario = await _usuarioService.CriarUsuarioAsync(usuarioDto);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }
    }
}
