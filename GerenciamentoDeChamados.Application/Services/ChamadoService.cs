using GerenciamentoDeChamados.Application.DTOs;
using GerenciamentoDeChamados.Application.Interfaces;
using GerenciamentoDeChamados.Domain.Entities;
using GerenciamentoDeChamados.Domain.Enums;
using System;
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

        public async Task<IEnumerable<ChamadoDto>> ObterTodosChamadosAsync()
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter os chamados.", ex);
            }
        }

        public async Task<ChamadoDto> ObterChamadoPorIdAsync(int id)
        {
            try
            {
                var chamado = await _chamadoRepository.ObterChamadoPorIdAsync(id);

                if (chamado == null)
                    return null;

                return new ChamadoDto
                {
                    Id = chamado.Id,
                    Descricao = chamado.Descricao,
                    Status = chamado.Status.ToString(),
                    UsuarioNome = chamado.Usuario.Nome,
                    UsuarioId = chamado.UsuarioId
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter o chamado com id {id}.", ex);
            }
        }

        public async Task<ChamadoDto> CriarChamadoAsync(ChamadoDto chamadoDto)
        {
            try
            {
                if (!Enum.TryParse<StatusChamado>(chamadoDto.Status, out var statusEnum))
                {
                    throw new ArgumentException("Status inválido.");
                }

                var chamado = new Chamado
                {
                    Descricao = chamadoDto.Descricao,
                    Status = statusEnum,
                    UsuarioId = chamadoDto.UsuarioId
                };

                chamado = await _chamadoRepository.CriarChamadoAsync(chamado);

                return new ChamadoDto
                {
                    Id = chamado.Id,
                    Descricao = chamado.Descricao,
                    Status = chamado.Status.ToString(),
                    UsuarioNome = chamado.Usuario.Nome
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar o chamado.", ex);
            }
        }

        public async Task<ChamadoDto> AtualizarChamadoAsync(int id, ChamadoDto chamadoDto)
        {
            try
            {
                var chamado = await _chamadoRepository.ObterChamadoPorIdAsync(id);

                if (chamado == null)
                    return null;

                if (!Enum.TryParse<StatusChamado>(chamadoDto.Status, out var statusEnum))
                {
                    throw new ArgumentException("Status inválido.");
                }

                chamado.Descricao = chamadoDto.Descricao;
                chamado.Status = statusEnum;
                chamado.UsuarioId = chamadoDto.UsuarioId;

                chamado = await _chamadoRepository.AtualizarChamadoAsync(chamado);

                return new ChamadoDto
                {
                    Id = chamado.Id,
                    Descricao = chamado.Descricao,
                    Status = chamado.Status.ToString(),
                    UsuarioNome = chamado.Usuario.Nome
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar o chamado com id {id}.", ex);
            }
        }

        public async Task<bool> DeletarChamadoAsync(int id)
        {
            try
            {
                var chamado = await _chamadoRepository.ObterChamadoPorIdAsync(id);

                if (chamado == null)
                    return false;

                // Passando o ID para o repositório
                await _chamadoRepository.DeletarChamadoAsync(id);  // Aqui você passa o ID

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar o chamado com id {id}.", ex);
            }
        }
    }
}
