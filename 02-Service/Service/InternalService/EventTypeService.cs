﻿using Common;
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
    public interface IEventTypeService
    {
        IEnumerable<EventType> GetAll();
        EventType GetById(int id);
        ResponseHelper InsertUpdate(EventType model);
        ResponseHelper Delete(int id);
    }

    public class EventTypeService : IEventTypeService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();
            try
            {

                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest("/eventtype/Delete", Method.POST);

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

        public EventType GetById(int id)
        {
            var result = new EventType();

            try
            {
                var resultreposnse = Common.RestHelper.DoResourceServerGET(String.Format("/eventtype/GetById/{0}", id));
                String json = Newtonsoft.Json.JsonConvert.SerializeObject(resultreposnse.Result);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<EventType>(json);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public IEnumerable<EventType> GetAll()
        {
            var result = new List<EventType>();
            try
            {
                var resultreposnse = Common.RestHelper.DoResourceServerGET("/eventtype/GetAll");
                String json = Newtonsoft.Json.JsonConvert.SerializeObject(resultreposnse.Result);
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EventType>>(json);

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ResponseHelper InsertUpdate(EventType model)
        {
            var rh = new ResponseHelper();
            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest("/eventtype/InsertUpdate", Method.POST);

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
