using Common;
using Model.Domain;
using NLog;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.InternalService
{
    public interface IPermissionUserService
    {
        IEnumerable<PermissionUser> GetByUserId(Guid userId);

    }


    public class PermissionUserService : IPermissionUserService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public IEnumerable<PermissionUser> GetByUserId(Guid userId)
        {
            var result = new List<PermissionUser>();
            List<string> _roles = new List<string>();
            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest(string.Format("/permissionUser/GetByUserId/{0}",userId),
                    Method.GET);

                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                IRestResponse<List<PermissionUser>> response = 
                    client.Execute<List<PermissionUser>>(request);

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
