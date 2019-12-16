using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using uniaraxaMinimundo.Dominio.Entidades;
using uniaraxaMinimundo.Dominio.Interfaces.Servico.uniaraxaMinimundo;
using uniaraxaMinimundo.Servico.Base;

namespace uniaraxaMinimundo.Servico.Validators
{
    public class ServiceAvaliacaoSugestao : IAvaliacaoSugestaoService
    {
        private ServiceBase<AvaliacaoSugestao> Base = new ServiceBase<AvaliacaoSugestao>();

        public void Delete(AvaliacaoSugestao obj)
        {
            Base.Delete(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Insert<V>(AvaliacaoSugestao obj) where V : AbstractValidator<AvaliacaoSugestao>
        {
            Base.Validate(obj, Activator.CreateInstance<V>());
            var result = Base.SelectAll()
                .Where(f => f.SugestaoID == obj.SugestaoID)
                .FirstOrDefault();

            if (result == null)
                Base.Insert<AvaliacaoSugestaoValidator>(obj);
            else
                throw new ArgumentException("Avaliação de sugestão já cadastrado");
        }

        public AvaliacaoSugestao Select(int id)
        {
            return Base.Select(id);
        }

        public AvaliacaoSugestao Select(string key)
        {
            return Base.Select(key);
        }

        public IEnumerable<AvaliacaoSugestao> SelectAll()
        {
            return Base.SelectAll();
        }

        public void Update<V>(AvaliacaoSugestao obj) where V : AbstractValidator<AvaliacaoSugestao>
        {
            Base.Validate(obj, Activator.CreateInstance<V>());
            var result = Base.SelectAll()
                .Where(f => f.SugestaoID == obj.SugestaoID)
                .FirstOrDefault();
            if (result != null)
                Base.Update<AvaliacaoSugestaoValidator>(obj);
            else
                throw new ArgumentException("Avaliacão de sugestão não encontrado");
        }
    }
}
