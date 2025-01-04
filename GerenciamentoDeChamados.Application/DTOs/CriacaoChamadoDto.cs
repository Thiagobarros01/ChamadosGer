using GerenciamentoDeChamados.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeChamados.Application.DTOs
{
    class CriacaoChamadoDto
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public PrioridadeChamado Prioridade { get; set; }
        public string UsuarioNome { get; set; }
        public int UsuarioId { get; set; } // Alterado para int
    }
}
