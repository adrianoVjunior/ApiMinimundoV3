using FluentValidation;
using System;
using System.Collections.Generic;
using uniaraxaMinimundo.Dominio.Entidades;
using uniaraxaMinimundo.Dominio.Interfaces.Servico.uniaraxaMinimundo;
using uniaraxaMinimundo.Servico.Base;
using uniaraxaMinimundo.Servico.Validators;

namespace uniaraxaMinimundo.Servico
{
    public class ServiceUsuario : IUsuarioService
    {
        private ServiceBase<Usuario> Base = new ServiceBase<Usuario>();

        public void Delete(Usuario obj)
        {
            Base.Delete(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Insert<V>(Usuario obj) where V : AbstractValidator<Usuario>
        {
            Base.Validate(obj, Activator.CreateInstance<V>());
            var result = Base.Select(obj.Nome);

            if (result == null)
                Base.Insert<UsuarioValidator>(obj);
            else
                throw new ArgumentException("Usuário já cadastrado");
        }

        public Usuario Select(int id)
        {
            return Base.Select(id);
        }

        public Usuario Select(string key)
        {
            return Base.Select(key);
        }
        public IEnumerable<Usuario> SelectAll()
        {
            return Base.SelectAll();
        }

        public void Update<V>(Usuario obj) where V : AbstractValidator<Usuario>
        {
            Base.Validate(obj, Activator.CreateInstance<V>());
            var result = Base.Select(obj.Nome);

            if (result != null)
                Base.Update<UsuarioValidator>(obj);
            else
                throw new ArgumentException("Usuário não encontrado");
        }
    }
}
