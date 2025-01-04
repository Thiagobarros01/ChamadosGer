using GerenciamentoDeChamados.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeChamados.Application.DTOs
{
    public class ChamadoDto
    {
        public int Id { get; set; } // Alterado para int
        public string Descricao { get; set; }
        public string Titulo { get; set; }
        public string Status { get; set; }
        public string Prioridade { get; set; }
        public string UsuarioNome { get; set; }
        public int UsuarioId { get; set; } // Alterado para int
    }
}
