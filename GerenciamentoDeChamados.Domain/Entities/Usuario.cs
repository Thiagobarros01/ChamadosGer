﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeChamados.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        // Relacionamento com Chamados
        public ICollection<Chamado> Chamados { get; set; } = new List<Chamado>();
    }
}
