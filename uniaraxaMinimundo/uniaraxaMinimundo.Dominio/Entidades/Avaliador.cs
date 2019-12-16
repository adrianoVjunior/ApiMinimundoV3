using System;
using System.Collections.Generic;
using System.Text;

namespace uniaraxaMinimundo.Dominio.Entidades
{
    public class Avaliador
    {
        public int AvaliadorID { get; set; }
        public int UsuarioID { get; set; }
        public Usuario usuario { get; set; }
    }
}
