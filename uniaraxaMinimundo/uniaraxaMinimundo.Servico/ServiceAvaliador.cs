using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using uniaraxaMinimundo.Dominio.Entidades;
using uniaraxaMinimundo.Dominio.Interfaces.Servico.uniaraxaMinimundo;
using uniaraxaMinimundo.Servico.Base;
using uniaraxaMinimundo.Servico.Validators;

namespace uniaraxaMinimundo.Servico
{
    public class ServiceAvaliador : IAvaliadorService
    {
        private ServiceBase<Avaliador> Base = new ServiceBase<Avaliador>();

        public void Delete(Avaliador obj)
        {
            Base.Delete(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Insert<V>(Avaliador obj) where V : AbstractValidator<Avaliador>
        {
            Base.Validate(obj, Activator.CreateInstance<V>());
            var result = Base.SelectAll().Where(f => f.UsuarioID == obj.UsuarioID).FirstOrDefault();

            if (result == null)
                Base.Insert<AvaliadorValidator>(obj);
            else
                throw new ArgumentException("Avalidor já cadastrado");
        }

        public Avaliador Select(int id)
        {
            return Base.Select(id);
        }

        public Avaliador Select(string key)
        {
            return Base.Select(key);
        }

        public IEnumerable<Avaliador> SelectAll()
        {
            return Base.SelectAll();
        }

        public void Update<V>(Avaliador obj) where V : AbstractValidator<Avaliador>
        {
            Base.Validate(obj, Activator.CreateInstance<V>());
            var result = Base.SelectAll().Where(f => f.UsuarioID == obj.UsuarioID).FirstOrDefault();
            if (result != null)
                Base.Update<AvaliadorValidator>(obj);
            else
                throw new ArgumentException("Avalidor não encontrado");
        }
    }
}
