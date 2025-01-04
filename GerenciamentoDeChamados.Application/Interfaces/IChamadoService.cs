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
        Task<IEnumerable<ChamadoDto>> ObterTodosChamadosAsync();
        Task<ChamadoDto> ObterChamadoPorIdAsync(int id);
        Task<ChamadoDto> CriarChamadoAsync(ChamadoDto chamadoDto);
        Task<ChamadoDto> AtualizarChamadoAsync(int id, ChamadoDto chamadoDto);
        Task<bool> DeletarChamadoAsync(int id);
    }
}
