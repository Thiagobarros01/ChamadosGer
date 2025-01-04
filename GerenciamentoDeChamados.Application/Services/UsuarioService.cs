using GerenciamentoDeChamados.Application.DTOs;
using GerenciamentoDeChamados.Application.Interfaces;
using GerenciamentoDeChamados.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeChamados.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDto> ObterUsuarioPorIdAsync(int id)
        {
            var usuario = await _usuarioRepository.ObterUsuarioPorIdAsync(id);

            if (usuario == null)
                return null;

            return new UsuarioDto
            {
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
                Id = usuario.Id,  // Vai pegar o Id gerado automaticamente
                Nome = usuario.Nome,
                Email = usuario.Email
            };
        }

        public async Task<IEnumerable<UsuarioDto>> ObterTodosUsuariosAsync()
        {
            var usuarios = await _usuarioRepository.ObterTodosUsuariosAsync();

            return usuarios.Select(usuario => new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            });
        }

        public async Task<UsuarioDto> AtualizarUsuarioAsync(int id, UsuarioDto usuarioDto)
        {
            var usuario = await _usuarioRepository.ObterUsuarioPorIdAsync(id);

            if (usuario == null)
                return null;

            usuario.Nome = usuarioDto.Nome;
            usuario.Email = usuarioDto.Email;
            usuario.Senha = usuarioDto.Senha;

            usuario = await _usuarioRepository.AtualizarUsuarioAsync(usuario);

            return new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            };
        }

        public async Task<bool> DeletarUsuarioAsync(int id)
        {
            var usuario = await _usuarioRepository.ObterUsuarioPorIdAsync(id);

            if (usuario == null)
                return false;

            return await _usuarioRepository.DeletarUsuarioAsync(id);
        }
    }
}
