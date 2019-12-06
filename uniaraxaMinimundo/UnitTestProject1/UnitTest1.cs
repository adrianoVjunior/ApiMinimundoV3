using Microsoft.VisualStudio.TestTools.UnitTesting;
using uniaraxaMinimundo.Dominio.Entidades;
using uniaraxaMinimundo.Servico.Validators;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Usuario login = new Login();
            login.usuario = "abc";
            login.senha = "123";

            LoginValidator LoginValidator = new LoginValidator();
            var resultado = LoginValidator.Validate(login);
            Assert.AreEqual(false, resultado.IsValid);
        
        }
    }
}
