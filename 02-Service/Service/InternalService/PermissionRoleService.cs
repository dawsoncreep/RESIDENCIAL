using Common;
using Model.Domain;
using NLog;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Service.InternalService
{
    public interface IPermissionRoleService
    {
        IEnumerable<PermissionRole> GetByRoleId(Guid userId);
        IEnumerable<PermissionRole> GetAll();

    }


    public class PermissionRoleService : IPermissionRoleService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public IEnumerable<PermissionRole> GetAll()
        {
            var result = new List<PermissionRole>();
            List<string> _roles = new List<string>();
            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest("/permissionRole/GetAll",Method.GET);

                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                IRestResponse<List<PermissionRole>> response =
                    client.Execute<List<PermissionRole>>(request);

                result = response.Data;

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public IEnumerable<PermissionRole> GetByRoleId(Guid roleId)
        {
            var result = new List<PermissionRole>();
            List<string> _roles = new List<string>();
            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest(string.Format("/permissionRole/GetByRoleId/{0}", roleId),
                    Method.GET);

                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                IRestResponse<List<PermissionRole>> response = 
                    client.Execute<List<PermissionRole>>(request);

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
