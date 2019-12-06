using System;
using System.ComponentModel.DataAnnotations;

namespace uniaraxaMinimundo.Dominio.Entidades
{
    public class Login : BaseEntity
    {
        public int userToken_ID { get; set; }
        public String usuario { get; set; }
        public String senha { get; set; }
    }
}
