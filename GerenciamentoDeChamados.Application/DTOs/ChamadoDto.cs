using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeChamados.Application.DTOs
{
    public class ChamadoDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public string UsuarioNome { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
