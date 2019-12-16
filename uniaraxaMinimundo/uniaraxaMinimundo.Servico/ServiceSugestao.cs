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
    public class ServiceSugestao : ISugestaoService
    {
        private ServiceBase<Sugestao> Base = new ServiceBase<Sugestao>();

        public void Delete(Sugestao obj)
        {
            Base.Delete(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Insert<V>(Sugestao obj) where V : AbstractValidator<Sugestao>
        {
            Base.Validate(obj, Activator.CreateInstance<V>());
            var result = Base.SelectAll()
                .Where(f => (f.CampanhaID == obj.CampanhaID && f.FuncionarioID == obj.FuncionarioID))
                .FirstOrDefault();

            if (result == null)
                Base.Insert<SugestaoValidator>(obj);
            else
                throw new ArgumentException("Sugestão já cadastrado");
        }

        public Sugestao Select(int id)
        {
            return Base.Select(id);
        }

        public Sugestao Select(string key)
        {
            return Base.Select(key);
        }

        public IEnumerable<Sugestao> SelectAll()
        {
            return Base.SelectAll();
        }

        public void Update<V>(Sugestao obj) where V : AbstractValidator<Sugestao>
        {
            Base.Validate(obj, Activator.CreateInstance<V>());
            var result = Base.SelectAll()
                .Where(f => (f.CampanhaID == obj.CampanhaID && f.FuncionarioID == obj.FuncionarioID))
                .FirstOrDefault();
            if (result != null)
                Base.Update<SugestaoValidator>(obj);
            else
                throw new ArgumentException("Sugestão não encontrado");
        }
    }
}
