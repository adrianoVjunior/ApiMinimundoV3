using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace uniaraxaMinimundo.Dominio.Interfaces.Servico
{
    public interface IServiceBase<TEntity> where TEntity :class
    {
        TEntity Select(int id);
        TEntity Select(String key);
        void Update<Valida>(TEntity obj) where Valida : AbstractValidator<TEntity>;
        void Insert(TEntity obj);
        void Delete(TEntity id);
    }
}
