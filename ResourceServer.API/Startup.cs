using Common;
using Common.Config;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ResourceServer.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            ParamaterConfig.Initialize();

            ConfigureOAuth(app);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            app.UseWebApi(config);

        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            var issuer = Parameters.Iss; //"http://jwtauthzsrv.azurewebsites.net";
            var audience = Parameters.audId;  //"099153c2625149bc8ecb3e85e03f0022";
            var secret = TextEncodings.Base64Url.Decode(Parameters.Sec);

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audience },
                    IssuerSecurityKeyProviders = new IIssuerSecurityKeyProvider[]
                    {
                        new SymmetricKeyIssuerSecurityKeyProvider(issuer,secret)
                    }
                });

        }
    }
}