using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;
using uniaraxaMinimundo.Dominio.Interfaces.Servico.uniaraxaMinimundo;
using uniaraxaMinimundo.Servico.Base;
using uniaraxaMinimundo.Servico.Validators;

namespace uniaraxaMinimundo.Servico
{
    public class ServiceCampanha : ICampanhaService
    {
        private ServiceBase<Campanha> Base = new ServiceBase<Campanha>();

        public void Delete(Campanha obj)
        {
            Base.Delete(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Insert<V>(Campanha obj) where V : AbstractValidator<Campanha>
        {
            Base.Validate(obj, Activator.CreateInstance<V>());
            var result = Base.SelectAll()
                .Where(f => f.AvaliadorID == obj.AvaliadorID && f.EmpresaID == obj.EmpresaID)
                .FirstOrDefault();

            if (result == null)
                Base.Insert<CampanhaValidator>(obj);
            else
                throw new ArgumentException("Avalidor já cadastrado");
        }

        public Campanha Select(int id)
        {
            return Base.Select(id);
        }

        public Campanha Select(string key)
        {
            return Base.Select(key);
        }

        public IEnumerable<Campanha> SelectAll()
        {
            return Base.SelectAll();
        }

        public void Update<V>(Campanha obj) where V : AbstractValidator<Campanha>
        {
            Base.Validate(obj, Activator.CreateInstance<V>());
            var result = Base.SelectAll()
                .Where(f => f.AvaliadorID == obj.AvaliadorID && f.EmpresaID == obj.EmpresaID)
                .FirstOrDefault();
            if (result != null)
                Base.Update<CampanhaValidator>(obj);
            else
                throw new ArgumentException("Avalidor não encontrado");
        }
    }
}
