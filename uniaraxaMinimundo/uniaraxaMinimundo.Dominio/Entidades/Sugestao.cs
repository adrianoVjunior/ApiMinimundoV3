using System;
using System.Collections.Generic;
using System.Text;

namespace uniaraxaMinimundo.Dominio.Entidades
{
    public class Sugestao
    {
        public int SugestaoID { get; set; }
        public int CampanhaID { get; set; }
        public int FuncionarioID { get; set; }
        public String Descricao { get; set; }
        public Decimal Valor { get; set; }

        public Campanha campanha { get; set; }
        public Funcionario funcionario { get; set; }
    }
}
