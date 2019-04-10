using Common;
using Model.Auth;
using NLog;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Service.InternalService
{

    public interface IRoleService
    {
        IEnumerable<ApplicationRole> GetAll();
        ApplicationRole Get(string roleName);
        ApplicationRole Get(Guid id);
    }

    public class RoleService : IRoleService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public ApplicationRole Get(string roleName)
        {
            var result = new ApplicationRole();

            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest(String.Format("/role/Get/{0}", roleName), Method.GET);

                // easily add HTTP Headers
                //En caso de requerir autenticación hay que extraer el token de la cookie.
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                // execute the request
                //RestResponse<ApplicationUser> responseUsers = client.Execute<ApplicationUser>(request);
                //var content = response.Content; // raw content as string
                var asyncHandle = client.ExecuteAsync<ApplicationRole>(request, response => {
                    result = response.Data;  
                });

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public IEnumerable<ApplicationRole> GetAll()
        {
            List<ApplicationRole> result = new List<ApplicationRole>();

            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest("/role/GetAll", Method.GET);

                // easily add HTTP Headers
                //En caso de requerir autenticación hay que extraer el token de la cookie.
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                // execute the request
                IRestResponse<List<ApplicationRole>> response = client.Execute<List<ApplicationRole>>(request);
                result = response.Data;

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ApplicationRole Get(Guid id)
        {
            var result = new ApplicationRole();

            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest(String.Format("/role/GetById/{0}", id), Method.GET);

                // easily add HTTP Headers
                //En caso de requerir autenticación hay que extraer el token de la cookie.
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                // execute the request
                IRestResponse<ApplicationRole> response = client.Execute<ApplicationRole>(request);
                result = response.Data;


            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }
    }
}
