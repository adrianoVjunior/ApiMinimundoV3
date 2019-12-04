using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;
using uniaraxaMinimundo.Dominio.Interfaces.Repositorio;
using uniaraxaMinimundo.Infra.Data.EntityFramework.Context;

namespace uniaraxaMinimundo.Infra.Data.Repository.Base
{
    public class RepositoryBase<TEntity> : IRespositoryBase<TEntity> where TEntity : BaseEntity
    {
        private myContext context = new myContext();

        public void Delete(TEntity obj)
        {
            context.Set<TEntity>().Remove(obj);
            context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity obj)
        {
            context.Set<TEntity>().Add(obj);
            context.SaveChanges();
        }

        public TEntity Select(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IList<TEntity> SelectALL()
        {
            return context.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
