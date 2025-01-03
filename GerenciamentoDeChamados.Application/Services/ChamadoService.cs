using GerenciamentoDeChamados.Application.DTOs;
using GerenciamentoDeChamados.Application.Interfaces;
using GerenciamentoDeChamados.Domain.Entities;
using GerenciamentoDeChamados.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeChamados.Application.Services
{
    public class ChamadoService : IChamadoService
    {
        private readonly IChamadoRepository _chamadoRepository;

        public ChamadoService(IChamadoRepository chamadoRepository)
        {
            _chamadoRepository = chamadoRepository;
        }

        public async Task<IEnumerable<ChamadoDto>> ObterChamadosAsync()
        {
            var chamados = await _chamadoRepository.ObterChamadosAsync();

            return chamados.Select(c => new ChamadoDto
            {
                Id = c.Id,
                Descricao = c.Descricao,
                Status = c.Status.ToString(), 
                UsuarioNome = c.Usuario.Nome,
                UsuarioId = c.UsuarioId
            });
        }

        public async Task<ChamadoDto> CriarChamadoAsync(ChamadoDto chamadoDto)
        {
            // Converte o Status de string para o tipo enum StatusChamado
            var statusEnum = Enum.Parse<StatusChamado>(chamadoDto.Status);

            var chamado = new Chamado
            {
                Descricao = chamadoDto.Descricao,
                Status = statusEnum,  // Atribui o valor convertido do enum
                UsuarioId = chamadoDto.UsuarioId
            };

            // Cria o chamado e salva no repositório
            chamado = await _chamadoRepository.CriarChamadoAsync(chamado);

            // Retorna o DTO com os dados do chamado, incluindo o Status convertido para string
            return new ChamadoDto
            {
                Id = chamado.Id,
                Descricao = chamado.Descricao,
                Status = chamado.Status.ToString(),  // Converte de volta para string ao retornar
                UsuarioNome = chamado.Usuario.Nome
            };
        }
    }
}
