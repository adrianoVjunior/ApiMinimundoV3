using System;
using System.Collections.Generic;
using System.Text;
using static uniaraxaMinimundo.Dominio.Interfaces.Models;

namespace uniaraxaMinimundo.Dominio.Entidades
{
    public class Usuario : Login
    {
        public int UsuarioID { get; set; }
        public String Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public String CPF { get; set; }
        public String Email { get; set; }
    }
}
