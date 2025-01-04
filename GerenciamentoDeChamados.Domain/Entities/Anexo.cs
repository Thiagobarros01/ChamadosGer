using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeChamados.Domain.Entities
{
    public class Anexo
    {
        public int Id { get; set; } // Alterado para int
        public string NomeArquivo { get; set; } = string.Empty;
        public string CaminhoArquivo { get; set; } = string.Empty;
        public DateTime DataUpload { get; set; } = DateTime.UtcNow;

        // Relacionamento com Chamado
        public int ChamadoId { get; set; } // Alterado para int
        public Chamado Chamado { get; set; }
    }
}
