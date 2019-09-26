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
        ResponseHelper InsertUpdate(PermissionRole model);
        ResponseHelper Delete(int id);
        PermissionRole GetById(int id);


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

        public ResponseHelper InsertUpdate(PermissionRole model)
        {
            var rh = new ResponseHelper();
            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest("/permissionRole/InsertUpdate", Method.POST);

                request.Parameters.Add(new Parameter
                {
                    Name = "model",
                    ContentType = "application/json",
                    DataFormat = DataFormat.Json,
                    Type = ParameterType.RequestBody,
                    Value = model
                });
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");


                IRestResponse<ResponseHelper> response = client.Execute<ResponseHelper>(request);

                rh = response.Data;

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return rh;
        }

        public PermissionRole GetById(int id)
        {
            var result = new PermissionRole();
            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest(String.Format("/permissionRole/GetById/{0}", id), Method.GET);

                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                IRestResponse<ResponseHelper<PermissionRole>> response =
                    client.Execute<ResponseHelper<PermissionRole>>(request);
                if (response.Data.Response)
                {
                    var jsonStrong = response.Data.Result;
                    result = response.Data.Result;
                }

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;

        }

        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();
            try
            {

                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest("/permissionRole/Delete", Method.POST);

                request.Parameters.Add(new Parameter
                {
                    Name = "model",
                    ContentType = "application/json",
                    DataFormat = DataFormat.Json,
                    Type = ParameterType.RequestBody,
                    Value = GetById(id)
                });
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");


                IRestResponse<ResponseHelper> response = client.Execute<ResponseHelper>(request);

                rh = response.Data;

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return rh;
        }
    }

}
