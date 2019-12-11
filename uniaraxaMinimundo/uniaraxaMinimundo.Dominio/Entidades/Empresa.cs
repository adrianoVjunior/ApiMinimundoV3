using System;
using System.Collections.Generic;
using System.Text;

namespace uniaraxaMinimundo.Dominio.Entidades
{
    public class Empresa
    {
        public int EmpresaID { get; set; }
        public String NomeFantasia { get; set; }
        public String RazaoSocial { get; set; }
        public String CNPJ { get; set; }
        public String IE { get; set; }
    }
}
