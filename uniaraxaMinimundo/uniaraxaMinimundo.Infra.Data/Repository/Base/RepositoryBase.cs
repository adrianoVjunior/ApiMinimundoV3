using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using uniaraxaMinimundo.Dominio.Interfaces.Repositorio;
using uniaraxaMinimundo.Infra.Data.EntityFramework.Context;

namespace uniaraxaMinimundo.Infra.Data.Repository.Base
{
    public class RepositoryBase<TEntity> : IDisposable, IRespositoryBase<TEntity> where TEntity : class
    {
        protected uniaraxaMinimundoContext Db = new uniaraxaMinimundoContext(new DbContextOptions<uniaraxaMinimundoContext>
        { });

        public void Delete(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public TEntity Select(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IList<TEntity> SelectALL()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }
    }
}
