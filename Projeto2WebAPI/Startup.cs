using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Projeto2WebAPI.Services;

[assembly: OwinStartup(typeof(Projeto2WebAPI.Startup))]

namespace Projeto2WebAPI
{
    public class Startup //ativando recursos owin
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );

            app.UseCors(CorsOptions.AllowAll);

            AtivarGeracaoToken(app);


            app.UseWebApi(config);

            // Para obter mais informações sobre como configurar seu aplicativo, visite https://go.microsoft.com/fwlink/?LinkID=316888
        }

        private void AtivarGeracaoToken(IAppBuilder app)
        {
            var opcoesConfiguracaoToken = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1), //tempo que dura o token
                TokenEndpointPath = new PathString("/token"),
                Provider = new ProviderDeTokensDeAcesso(),
            };

            app.UseOAuthAuthorizationServer(opcoesConfiguracaoToken);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
