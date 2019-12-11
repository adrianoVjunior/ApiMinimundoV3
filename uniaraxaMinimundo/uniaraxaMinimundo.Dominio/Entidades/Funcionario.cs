using System;
using System.Collections.Generic;
using System.Text;

namespace uniaraxaMinimundo.Dominio.Entidades
{
    public class Funcionario
    {
        public int FuncionarioID { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioID { get; set; }
        public int EmpresaID { get; set; }
        public Empresa Empresa { get; set; }
        public Usuario Usuario { get; set; }
    }
}
