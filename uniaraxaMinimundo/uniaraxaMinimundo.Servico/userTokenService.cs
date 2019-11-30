using uniaraxaMinimundo.Dominio.Entidades;
using uniaraxaMinimundo.Dominio.Interfaces.Repositorio.uniaraxaMinimundo;
using uniaraxaMinimundo.Dominio.Interfaces.Servico.uniaraxaMinimundo;
using uniaraxaMinimundo.Servico.Base;

namespace uniaraxaMinimundo.Servico
{
    public class userTokenService : ServiceBase<userToken>, IUserTokenService
    {
        private readonly IUserTokenRepository _userTokenRepository;

        public userTokenService(IUserTokenRepository userTokenRepository) : base(userTokenRepository)
        {
            _userTokenRepository = userTokenRepository;
        }
    }
}
