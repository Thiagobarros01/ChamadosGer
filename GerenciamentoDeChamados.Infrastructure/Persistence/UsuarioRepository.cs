using GerenciamentoDeChamados.Application.Interfaces;
using GerenciamentoDeChamados.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GerenciamentoDeChamados.Infrastructure.Persistence
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ObterUsuarioPorIdAsync(int id)
        {
            try
            {
                return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            }
            catch (Exception ex)
            {
                // Log de erro
                throw new Exception($"Erro ao obter o usuário com ID {id}.", ex);
            }
        }

        public async Task<Usuario> CriarUsuarioAsync(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return usuario;
            }
            catch (Exception ex)
            {
                // Log de erro
                throw new Exception("Erro ao criar o usuário.", ex);
            }
        }

        public async Task<Usuario> AtualizarUsuarioAsync(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
                return usuario;
            }
            catch (Exception ex)
            {
                // Log de erro
                throw new Exception("Erro ao atualizar o usuário.", ex);
            }
        }

        public async Task<bool> DeletarUsuarioAsync(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return false;  // Ao invés de lançar exceção, retorne 'false'
                }

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar o usuário.", ex);
            }
        }

        public async Task<IEnumerable<Usuario>> ObterTodosUsuariosAsync()
        {
            try
            {
                return await _context.Usuarios.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter todos os usuários.", ex);
            }
        }
    }
}
