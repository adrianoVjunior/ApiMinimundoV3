using System;
using System.Collections.Generic;
using System.Text;

namespace uniaraxaMinimundo.Dominio.Interfaces.Repositorio
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity Select(int id);
        TEntity Select(string key);
        IList<TEntity> SelectAll();
        void Update(TEntity obj);
        void Insert(TEntity obj);
        void Delete(TEntity obj);
        void Dispose();
    }
}
