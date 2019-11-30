using System;
using System.Collections.Generic;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;
using uniaraxaMinimundo.Dominio.Interfaces.Repositorio.uniaraxaMinimundo;
using uniaraxaMinimundo.Infra.Data.Repository.Base;

namespace uniaraxaMinimundo.Infra.Data.Repository
{
    public class userTokenRepository: RepositoryBase<userToken>, IUserTokenRepository
    {
    }
}
