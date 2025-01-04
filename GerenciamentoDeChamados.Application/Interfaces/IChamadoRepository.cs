using GerenciamentoDeChamados.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeChamados.Application.Interfaces
{
    public interface IChamadoRepository
    {
        Task<IEnumerable<Chamado>> ObterChamadosAsync();
        Task<Chamado> ObterChamadoPorIdAsync(int id);
        Task<Chamado> CriarChamadoAsync(Chamado chamado);
        Task<Chamado> AtualizarChamadoAsync(Chamado chamado);
        Task<bool> DeletarChamadoAsync(int id);  // Método com ID
    }
}
