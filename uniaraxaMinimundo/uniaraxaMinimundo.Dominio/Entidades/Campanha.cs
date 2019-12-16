using System;
using System.Collections.Generic;
using System.Text;

namespace uniaraxaMinimundo.Dominio.Entidades
{
    public class Campanha
    {
        public int CampanhaID { get; set; }
        public int AvaliadorID { get; set; }
        public int EmpresaID { get; set; }
        public String CampanhaNome { get; set; }
        public String Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Decimal ValorPremio { get; set; }
    }
}
