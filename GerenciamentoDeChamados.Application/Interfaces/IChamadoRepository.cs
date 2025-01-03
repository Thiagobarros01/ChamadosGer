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
        Task<Chamado> CriarChamadoAsync(Chamado chamado);
    }
}
