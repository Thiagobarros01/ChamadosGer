﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeChamados.Application.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }  // Alterado para int
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
