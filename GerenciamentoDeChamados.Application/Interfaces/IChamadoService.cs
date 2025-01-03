using GerenciamentoDeChamados.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeChamados.Application.Interfaces
{
    public interface IChamadoService
    {
        Task<IEnumerable<ChamadoDto>> ObterChamadosAsync();
        Task<ChamadoDto> CriarChamadoAsync(ChamadoDto chamadoDto);
    }
}
