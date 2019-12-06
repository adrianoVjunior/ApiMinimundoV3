using System;
using System.Collections.Generic;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;
using uniaraxaMinimundo.Dominio.Interfaces.Servico.uniaraxaMinimundo;
using uniaraxaMinimundo.Servico.Base;
using uniaraxaMinimundo.Servico.Validators;

namespace uniaraxaMinimundo.Servico
{
    public class ServiceUsuario : IUsuarioService<Usuario>
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

        public void Insert(Usuario obj)
        {
            Base.Insert(obj);
        }

        public Usuario Select(int id)
        {
            return Base.Select(id);
        }

        public Usuario Select(string key)
        {
            return Base.Select(key);
        }

        public void Update(Usuario obj)
        {
            //Base.Update(obj,UsuarioValidator);
            throw new NotImplementedException();
        }
    }
}
