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
    public class ServiceFuncionario : IFuncionarioService
    {
        private ServiceBase<Funcionario> Base = new ServiceBase<Funcionario>();

        public void Delete(Funcionario obj)
        {
            Base.Delete(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Insert<V>(Funcionario obj) where V : AbstractValidator<Funcionario>
        {
            Base.Validate(obj, Activator.CreateInstance<V>());
            var result = Base.SelectAll()
                .Where(f => (f.UsuarioID == obj.UsuarioID && f.EmpresaID == obj.EmpresaID))
                .FirstOrDefault();

            if (result == null)
                Base.Insert<FuncionarioValidator>(obj);
            else
                throw new ArgumentException("Funcionário já cadastrado");
        }

        public Funcionario Select(int id)
        {
            return Base.Select(id);
        }

        public Funcionario Select(string key)
        {
            return Base.Select(key);
        }

        public IEnumerable<Funcionario> SelectAll()
        {
            return Base.SelectAll();
        }

        public void Update<V>(Funcionario obj) where V : AbstractValidator<Funcionario>
        {
            Base.Validate(obj, Activator.CreateInstance<V>());
            var result = Base.SelectAll()
                .Where(f => (f.UsuarioID == obj.UsuarioID && f.EmpresaID == obj.EmpresaID))
                .FirstOrDefault();
            if (result != null)
                Base.Update<FuncionarioValidator>(obj);
            else
                throw new ArgumentException("Funcionário não encontrado");
        }
    }
}
