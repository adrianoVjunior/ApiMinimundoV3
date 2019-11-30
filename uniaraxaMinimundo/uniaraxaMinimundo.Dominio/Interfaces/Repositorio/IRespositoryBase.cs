using System;
using System.Collections.Generic;
using System.Text;

namespace uniaraxaMinimundo.Dominio.Interfaces.Repositorio
{
    public interface IRespositoryBase<TEntity> where TEntity : class
    {
        TEntity Select(int id);
        IList<TEntity> SelectALL();
        void Update(TEntity obj);
        void Insert(TEntity obj);
        void Delete(TEntity obj);
        void Dispose();
    }
}
