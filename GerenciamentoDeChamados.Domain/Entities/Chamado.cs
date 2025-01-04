using GerenciamentoDeChamados.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeChamados.Domain.Entities
{
    public class Chamado
    {
        public int Id { get; set; } // Alterado para int
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public PrioridadeChamado Prioridade { get; set; } = PrioridadeChamado.Baixa;
        public StatusChamado Status { get; set; } = StatusChamado.Aberto;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime? DataAtualizacao { get; set; }

        // Relacionamento com Usuário
        public int UsuarioId { get; set; } // Alterado para int
        public Usuario Usuario { get; set; }

        // Relacionamento com Anexos
        public ICollection<Anexo> Anexos { get; set; } = new List<Anexo>();
    }


}

