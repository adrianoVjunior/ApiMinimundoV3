using System;
using System.Collections.Generic;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;
using uniaraxaMinimundo.Servico.Base;
using uniaraxaMinimundo.Dominio.Interfaces.Servico;
using uniaraxaMinimundo.Dominio.Interfaces.Servico.uniaraxaMinimundo;
using FluentValidation;

namespace uniaraxaMinimundo.Servico
{
    public class LoginService : ILoginService<Login>
    {
        private ServiceBase<Login> service = new ServiceBase<Login>();

        public void Delete(Login obj)
        {
            service.Delete(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Insert(Login obj)
        {
            var aux = service.Select(obj.usuario);
            if (aux == null)
                service.Insert(obj);
            else
                throw new Exception("Já existe login com o usuário " + obj.usuario);
        }

        public Login Select(int id)
        {
            return service.Select(id);
        }

        public Login Select(string key)
        {
            throw new NotImplementedException();
        }

        //public IList<Login> SelectALL()
        //{
        //    throw new NotImplementedException();
        //}

     
        public void teste()
        {
            throw new NotImplementedException();
        }

        public void Update(Login obj)
        {
            throw new NotImplementedException();
        }
    }
}
