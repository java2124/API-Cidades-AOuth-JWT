using Microsoft.Owin.Security.OAuth;
using Projeto2WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Projeto2WebAPI.Services
{
    public class ProviderDeTokensDeAcesso : OAuthAuthorizationServerProvider
    {

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context) //realiza validações quando usuário de autentifica usando token de acesso
        {
            context.Validated();
            return base.ValidateClientAuthentication(context);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context) //disponibiliza credenciais para o usuário
        {
            FuncionariosSistema funcionario = FuncionariosAutenticacao.Login(context.UserName, context.Password);
            if (funcionario != null) //Valida se informações passadas pelo cliente existem na classe
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType); //coloca credenciais do usuário no sistema
                identity.AddClaim(new Claim("usuario_logado", context.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, funcionario.Role)); //papel do usuário na autenticação
                context.Validated(identity);
            }
            else
            {
                context.SetError("Acesso Inválido!", "As credenciais informadas não são válidas");
            }

            return base.GrantResourceOwnerCredentials(context); //para não precisar colocar que o método é assíncrono, ficara assim com uma melhor implementação
        }
    }
}