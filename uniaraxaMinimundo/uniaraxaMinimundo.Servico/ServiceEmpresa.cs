using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using uniaraxaMinimundo.Dominio.Entidades;
using uniaraxaMinimundo.Dominio.Interfaces.Servico;
using uniaraxaMinimundo.Dominio.Interfaces.Servico.uniaraxaMinimundo;
using uniaraxaMinimundo.Servico.Base;
using uniaraxaMinimundo.Servico.Validators;

namespace uniaraxaMinimundo.Servico
{
    public class ServiceEmpresa : IEmpresaService
    {

        private ServiceBase<Empresa> Base = new ServiceBase<Empresa>();

        public void Delete(Empresa obj)
        {
            Base.Delete(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Insert<V>(Empresa obj) where V : AbstractValidator<Empresa>
        {
            Base.Validate(obj, Activator.CreateInstance<V>());
            var result = Base.SelectAll().Where(f => f.CNPJ == obj.CNPJ).FirstOrDefault();

            if (result == null)
                Base.Insert<EmpresaValidator>(obj);
            else
                throw new ArgumentException("Usuário já cadastrado");
        }

        public Empresa Select(int id)
        {
            return Base.Select(id);
        }

        public Empresa Select(string key)
        {
            return Base.Select(key);
        }

        public IEnumerable<Empresa> SelectAll()
        {
            return Base.SelectAll();
        }

        public void Update<V>(Empresa obj) where V : AbstractValidator<Empresa>
        {
            Base.Validate(obj, Activator.CreateInstance<V>());
            var result = Base.SelectAll().Where(f => f.CNPJ == obj.CNPJ).FirstOrDefault();
            if (result != null)
                Base.Update<EmpresaValidator>(obj);
            else
                throw new ArgumentException("Usuário não encontrado");
        }
    }
}
