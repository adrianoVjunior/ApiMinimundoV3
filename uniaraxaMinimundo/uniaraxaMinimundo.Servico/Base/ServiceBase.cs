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
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity :class
    {

        private RepositoryBase<TEntity> repository = new RepositoryBase<TEntity>();


        public void Delete(TEntity obj)
        {
            repository.Delete(obj);
        }

        public void Insert(TEntity obj)
        {
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

        public void Update<Valida>(TEntity obj) where Valida : AbstractValidator<TEntity>
        {
            Validador(obj, Activator.CreateInstance<Valida>());
            repository.Update(obj);
        }

        private void Validador(TEntity obj, AbstractValidator<TEntity> validador)
        {
            if (obj == null)
                throw new Exception("Registro nulo");
            validador.ValidateAndThrow(obj);
        }
    }    
}
