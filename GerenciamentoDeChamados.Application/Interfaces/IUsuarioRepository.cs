using GerenciamentoDeChamados.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeChamados.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterUsuarioPorIdAsync(Guid id);
        Task<Usuario> CriarUsuarioAsync(Usuario usuario);
    }
}
