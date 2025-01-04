using GerenciamentoDeChamados.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciamentoDeChamados.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterUsuarioPorIdAsync(int id);
        Task<Usuario> CriarUsuarioAsync(Usuario usuario);
        Task<Usuario> AtualizarUsuarioAsync(Usuario usuario);  // Adicionando o método para atualizar
        Task<bool> DeletarUsuarioAsync(int id);  // Adicionando o método para deletar
        Task<IEnumerable<Usuario>> ObterTodosUsuariosAsync();  // Método para obter todos os usuários
    }
}
