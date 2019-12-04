using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using uniaraxaMinimundo.Dominio.Entidades;
using uniaraxaMinimundo.Dominio.Interfaces.Servico.uniaraxaMinimundo;


namespace uniaraxaMinimundoWebApi.Controllers
{
    [Route("api/login")]
    public class LoginController : Controller
    {

        private readonly IUserTokenService _userTokenService;

        [AllowAnonymous]
        [HttpPost]
        public object post([FromBody]userToken userToken,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations)

        {
            bool credenciaisValidas = false;
            if (userToken != null && !String.IsNullOrWhiteSpace(userToken.usuario))
            {

                var usuarioBase = _userTokenService.Select(userToken.userTokenID);
                credenciaisValidas = (usuarioBase != null &&
                    userToken.usuario == usuarioBase.usuario &&
                    userToken.usuario == usuarioBase.senha);
            }

            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(userToken.usuario, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, userToken.usuario)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }
    }
}