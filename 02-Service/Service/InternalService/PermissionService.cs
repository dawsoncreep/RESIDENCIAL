using Common;
using Model.Custom;
using Model.Domain;
using NLog;
using RestSharp;
using System;
using System.Collections.Generic;


namespace Service.InternalService
{
    public interface IPermissionService
    {
        IEnumerable<Permission> GetAll();
        Permission GetById(int id);
        ResponseHelper InsertUpdate(Permission model);
        ResponseHelper Delete(int id);
    }


    public class PermissionService : IPermissionService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public ResponseHelper InsertUpdate(Permission model)
        {
            var rh = new ResponseHelper();
            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest("/permission/InsertUpdate", Method.POST);

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

        public IEnumerable<Permission> GetAll()
        {
            var result = new List<Permission>();
            List<string> _roles = new List<string>();
            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest("/permission/GetAll", Method.GET);

                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization",
                        String.Format("Bearer {0}",CurrentUserHelper.Get.AccessToken.access_token));


                IRestResponse<ResponseHelper> response = client.Execute<ResponseHelper>(request);

                result = response.Data.Result;

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public Permission GetById(int id)
        {
            var result = new Permission();

            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest(String.Format("/permission/GetById/{0}", id), Method.GET);

                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                IRestResponse<ResponseHelper<Permission>> response = client.Execute<ResponseHelper<Permission>>(request);
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

                var request = new RestRequest("/permission/Delete", Method.POST);

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
