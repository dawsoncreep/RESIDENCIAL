using System;

namespace TestMobile
{
    class Program
    {
        static void Main(string[] args)
        {


            Model.Domain.EventType et = new Model.Domain.EventType()
            {
                Description = "PoolParty"
            };

            // Ejemplo de ejecución POST (Agregar, Modificar o Eliminar registros)
            var postResult = AppService.AppCommon.AppRestRequest.DoResourceServerPOST("api/eventtype/InsertUpdate", et);

            var login = new AppService.Models.LoginModel()
            {
                username = "admin",
                password = "Admin123.",
                client_id = "ca8051b986b144bab4b85c76ae68e079",
                grant_type =  "password"

            };

            //Ejemplo de GET (obtener registros)
            var tokenResult = (AppService.Models.TokenResultHelper)AppService.AppCommon.AppRestRequest.Login(login, "oauth2/token").Result;

            //Ejemplo de llamada utilizando el Token
            if (!String.IsNullOrEmpty(tokenResult.access_token)) {
                var getResult = (System.Collections.Generic.List<Model.Domain.Permission>)
                    AppService.AppCommon.AppRestRequest.DoResourceServerGET("api/permission/GetAll",
                    tokenResult.access_token).Result;
            }
        }
    }
}
