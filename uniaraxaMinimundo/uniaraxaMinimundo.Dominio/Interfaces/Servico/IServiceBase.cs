using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace uniaraxaMinimundo.Dominio.Interfaces.Servico
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        TEntity Select(int id);
        TEntity Select(String key);
        IEnumerable<TEntity> SelectAll();
        void Update<V>(TEntity obj) where V : AbstractValidator<TEntity>;
        void Insert<V>(TEntity obj) where V : AbstractValidator<TEntity>;
        void Delete(TEntity id);
    }
}
