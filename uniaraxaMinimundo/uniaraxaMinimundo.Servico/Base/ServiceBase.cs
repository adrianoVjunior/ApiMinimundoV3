using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using uniaraxaMinimundo.Dominio.Interfaces.Repositorio;
using uniaraxaMinimundo.Dominio.Interfaces.Repositorio.uniaraxaMinimundo;
using uniaraxaMinimundo.Dominio.Interfaces.Servico;

namespace uniaraxaMinimundo.Servico.Base
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRespositoryBase<TEntity> _repositoryBase;
        private IUserTokenRepository userTokenRepository;

        public ServiceBase(IUserTokenRepository userTokenRepository)
        {
            this.userTokenRepository = userTokenRepository;
        }

        public void Delete(TEntity obj)
        {
            _repositoryBase.Delete(obj);
        }

        public void Dispose()
        {
            _repositoryBase.Dispose();
        }

        public void Insert(TEntity obj)
        {
            _repositoryBase.Insert(obj);
        }

        public TEntity Select(int id)
        {
            return _repositoryBase.Select(id);
        }

        public IList<TEntity> SelectALL()
        {
            return _repositoryBase.SelectALL();
        }

        public void Update<Valida>(TEntity obj) where Valida : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<Valida>());
            _repositoryBase.Update(obj);
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados");
            validator.ValidateAndThrow(obj);
        }
    }
}
