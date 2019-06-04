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
    public interface ILocationTypeService
    {
        IEnumerable<LocationType> GetAll();
        LocationType GetById(int id);
        ResponseHelper InsertUpdate(LocationType model);
        ResponseHelper Delete(int id);
    }


    public class LocationTypeService : ILocationTypeService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();
            try
            {

                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest("/locationtype/Delete", Method.POST);

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

        public IEnumerable<LocationType> GetAll()
        {
            var result = new List<LocationType>();
            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest("/locationtype/GetAll", Method.GET);

                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                IRestResponse<List<LocationType>> response = client.Execute<List<LocationType>>(request);

                result = response.Data;

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public LocationType GetById(int id)
        {
            var result = new LocationType();

            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest(String.Format("/locationtype/GetById/{0}", id), Method.GET);

                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                IRestResponse<ResponseHelper<LocationType>> response = 
                    client.Execute<ResponseHelper<LocationType>>(request);
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

        public ResponseHelper InsertUpdate(LocationType model)
        {
            var rh = new ResponseHelper();
            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest("/locationtype/InsertUpdate", Method.POST);

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
