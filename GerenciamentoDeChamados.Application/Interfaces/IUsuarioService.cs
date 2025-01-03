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
        Task<UsuarioDto> ObterUsuarioPorIdAsync(Guid id);
        Task<UsuarioDto> CriarUsuarioAsync(UsuarioDto usuarioDto);
    }
}
