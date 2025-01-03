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
    public class ChamadoRepository : IChamadoRepository
    {
        private readonly AppDbContext _context;

        public ChamadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Chamado>> ObterChamadosAsync()
        {
            return await _context.Chamados.Include(c => c.Usuario).ToListAsync();
        }

        public async Task<Chamado> CriarChamadoAsync(Chamado chamado)
        {
            _context.Chamados.Add(chamado);
            await _context.SaveChangesAsync();
            return chamado;
        }
    }
}
