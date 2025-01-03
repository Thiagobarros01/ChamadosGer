using GerenciamentoDeChamados.Application.Interfaces;
using GerenciamentoDeChamados.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<Usuario> ObterUsuarioPorIdAsync(Guid id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario> CriarUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
