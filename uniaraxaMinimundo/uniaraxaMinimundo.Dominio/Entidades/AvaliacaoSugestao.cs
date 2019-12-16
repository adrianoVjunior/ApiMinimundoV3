using System;
using System.Collections.Generic;
using System.Text;

namespace uniaraxaMinimundo.Dominio.Entidades
{
    public class AvaliacaoSugestao
    {
        public int AvaliacaoID { get; set; }
        public int SugestaoID { get; set; }
        public int Criatividade { get; set; }
        public int Investimento { get; set; }
        public int Tempo { get; set; }

        public Sugestao Sugestao { get; set; }
    }
}
