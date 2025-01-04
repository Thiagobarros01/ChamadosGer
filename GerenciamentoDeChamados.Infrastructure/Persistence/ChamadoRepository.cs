using GerenciamentoDeChamados.Application.Interfaces;
using GerenciamentoDeChamados.Domain.Entities;
using GerenciamentoDeChamados.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Chamado> ObterChamadoPorIdAsync(int id)
        {
            return await _context.Chamados.Include(c => c.Usuario).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Chamado> CriarChamadoAsync(Chamado chamado)
        {
            _context.Chamados.Add(chamado);
            await _context.SaveChangesAsync();
            return chamado;
        }

        public async Task<Chamado> AtualizarChamadoAsync(Chamado chamado)
        {
            _context.Chamados.Update(chamado);
            await _context.SaveChangesAsync();
            return chamado;
        }

        public async Task<bool> DeletarChamadoAsync(int id)
        {
            var chamado = await _context.Chamados.FirstOrDefaultAsync(c => c.Id == id);

            if (chamado == null)
                return false;

            _context.Chamados.Remove(chamado);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
