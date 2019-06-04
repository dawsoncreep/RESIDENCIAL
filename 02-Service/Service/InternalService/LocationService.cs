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
    public interface ILocationService
    {
        IEnumerable<Location> GetAll();
        IEnumerable<Location> GetByUserName(String userName);
        Location GetById(int id);
        ResponseHelper InsertUpdate(Location model);
        ResponseHelper Delete(int id);
    }


    public class LocationService : ILocationService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();
            try
            {

                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest("/location/Delete", Method.POST);

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

        public IEnumerable<Location> GetAll()
        {
            var result = new List<Location>();
            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest("/location/GetAll", Method.GET);

                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                IRestResponse<List<Location>> response = 
                    client.Execute<List<Location>>(request);

                result = response.Data;

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public Location GetById(int id)
        {
            var result = new Location();

            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest(String.Format("/location/GetById/{0}", id), Method.GET);

                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                IRestResponse<ResponseHelper<Location>> response = 
                    client.Execute<ResponseHelper<Location>>(request);
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

        public IEnumerable<Location> GetByUserName(string userName)
        {
            var rh = new ResponseHelper<List<Location>>();
            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest(String.Format("/location/GetByUserName/{0}", CurrentUserHelper.Get.UserName), Method.GET);

                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                IRestResponse<ResponseHelper<List<Location>>> response =
                    client.Execute<ResponseHelper<List<Location>>>(request);

                rh = response.Data;

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return rh.Result;
        }

        public ResponseHelper InsertUpdate(Location model)
        {
            var rh = new ResponseHelper();
            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest("/location/InsertUpdate", Method.POST);

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

    }
}
