using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;
using uniaraxaMinimundo.Dominio.Interfaces.Repositorio;
using uniaraxaMinimundo.Dominio.Interfaces.Repositorio.uniaraxaMinimundo;
using uniaraxaMinimundo.Dominio.Interfaces.Servico;
using uniaraxaMinimundo.Infra.Data.Repository.Base;

namespace uniaraxaMinimundo.Servico.Base
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : BaseEntity
    {

        private RepositoryBase<TEntity> repository = new RepositoryBase<TEntity>();

        //private readonly IRespositoryBase<TEntity> _repositoryBase;
        //private IUserTokenRepository userTokenRepository;


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

        public IList<TEntity> SelectALL()
        {
            throw new NotImplementedException();
        }

        public void Update<Valida>(TEntity obj) where Valida : AbstractValidator<TEntity>
        {
            throw new NotImplementedException();
        }
    }

        //public IList<TEntity> SelectALL()
        //{
        //    return repository.SelectALL();
        //}

        //public void Update<Valida>(TEntity obj) where Valida : AbstractValidator<TEntity>
        //{
        //    Validate(obj, Activator.CreateInstance<Valida>());
        //    repository.Update(obj);
        //}

        //private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        //{
        //    if (obj == null)
        //        throw new Exception("Registros não detectados");
        //    validator.ValidateAndThrow(obj);
        //}
    
}
