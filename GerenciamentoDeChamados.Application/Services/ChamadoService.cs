using GerenciamentoDeChamados.Application.DTOs;
using GerenciamentoDeChamados.Application.Interfaces;
using GerenciamentoDeChamados.Domain.Entities;
using GerenciamentoDeChamados.Domain.Enums;


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

                var Chamado = new Chamado
                {
                    Id = chamadoDto.Id,
                    Status = chamadoDto.Status,
                    Descricao = chamadoDto.Descricao,
                    Prioridade = chamadoDto.Prioridade,
                    Titulo = chamadoDto.Titulo,
                    UsuarioId = chamadoDto.UsuarioId,
                };

                await _chamadoRepository.CriarChamadoAsync(Chamado);
                
                             
                return new ChamadoDto
                {
                    Id = Chamado.Id,
                    Descricao = Chamado.Descricao,
                    Prioridade = Chamado.Prioridade,
                    Status = chamadoDto.Status,
                    Titulo = Chamado.Titulo,
                    UsuarioId = Chamado.UsuarioId,


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

             

                chamado.Descricao = chamadoDto.Descricao;
                chamado.Status = chamadoDto.Status;
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
