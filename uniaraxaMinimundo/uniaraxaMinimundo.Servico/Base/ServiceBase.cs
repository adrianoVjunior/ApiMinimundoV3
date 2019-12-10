using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;
using uniaraxaMinimundo.Dominio.Interfaces.Repositorio;
using uniaraxaMinimundo.Dominio.Interfaces.Repositorio.uniaraxaMinimundo;
using uniaraxaMinimundo.Dominio.Interfaces.Servico;
using uniaraxaMinimundo.Infra.Data.RepositoryBase.Base;

namespace uniaraxaMinimundo.Servico.Base
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {

        private RepositoryBase<TEntity> repository = new RepositoryBase<TEntity>();


        public void Delete(TEntity obj)
        {
            repository.Delete(obj);
        }

        public void Insert<V>(TEntity obj) where V : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<V>());
            repository.Insert(obj);
        }

        public TEntity Select(int id)
        {
            return repository.Select(id);
        }

        public TEntity Select(string key)
        {
            return repository.Select(key);
        }

        public IEnumerable<TEntity> SelectAll()
        {
            return repository.SelectAll();
        }

        public void Update<V>(TEntity obj) where V : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<V>());
            repository.Update(obj);
        }

        public void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
