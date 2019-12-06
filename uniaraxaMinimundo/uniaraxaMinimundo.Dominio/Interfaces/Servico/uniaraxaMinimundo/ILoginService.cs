using System;
using System.Collections.Generic;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;
using uniaraxaMinimundo.Dominio.Interfaces.Repositorio;

namespace uniaraxaMinimundo.Dominio.Interfaces.Servico.uniaraxaMinimundo
{
    public interface ILoginService<Login> : IRespositoryBase<Login> where Login  : BaseEntity
    {
         void teste();
    }
}
