using GerenciamentoDeChamados.Application.DTOs;
using GerenciamentoDeChamados.Application.Interfaces;
using GerenciamentoDeChamados.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace GerenciamentoDeChamados.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDto> ObterUsuarioPorIdAsync(Guid id)
        {
            var usuario = await _usuarioRepository.ObterUsuarioPorIdAsync(id);

            if (usuario == null)
                return null;

            return new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            };
        }

        public async Task<UsuarioDto> CriarUsuarioAsync(UsuarioDto usuarioDto)
        {
            var usuario = new Usuario
            {
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email,
                Senha = usuarioDto.Senha 
            };

            usuario = await _usuarioRepository.CriarUsuarioAsync(usuario);

            return new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            };
        }
    }
}

