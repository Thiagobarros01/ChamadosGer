using GerenciamentoDeChamados.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeChamados.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> ObterTodosUsuariosAsync();
        Task<UsuarioDto> ObterUsuarioPorIdAsync(int id);
        Task<UsuarioDto> CriarUsuarioAsync(UsuarioDto usuarioDto);
        Task<UsuarioDto> AtualizarUsuarioAsync(int id, UsuarioDto usuarioDto);
        Task<bool> DeletarUsuarioAsync(int id);
    }
}
