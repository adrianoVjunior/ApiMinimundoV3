using System;
using System.ComponentModel.DataAnnotations;

namespace uniaraxaMinimundo.Dominio.Entidades
{
    public class userToken
    {
        public int userTokenID { get; set; }
        public String usuario { get; set; }
        public String senha { get; set; }
    }
}
