using NLog;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class RestHelper
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public static ResponseHelper DoResourceServerPOST(String Url, Object data)
        {
            var rh = new ResponseHelper();

            try
            {

                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest(Url, Method.POST);

                request.Parameters.Add(new Parameter
                {
                    Name = "model",
                    ContentType = "application/json",
                    DataFormat = DataFormat.Json,
                    Type = ParameterType.RequestBody,
                    Value = data
                });
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                if (!String.IsNullOrEmpty(CurrentUserHelper.Get.AccessToken.access_token))
                {
                    request.AddHeader("Authorization",
                            String.Format("Bearer {0}", CurrentUserHelper.Get.AccessToken.access_token));
                }

                IRestResponse<ResponseHelper> response = client.Execute<ResponseHelper>(request);

                rh = response.Data;
                return rh;

            }
            catch (Exception e)
            {
                rh.Message = e.Message;
                rh.Response = false;
                logger.Error(e.Message);
                return rh;
            }
        }


        public static ResponseHelper DoResourceServerGET(String Url)
        {
            var rh = new ResponseHelper();

            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest(Url, Method.GET);

                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                if (!String.IsNullOrEmpty(CurrentUserHelper.Get.AccessToken.access_token))
                {
                    request.AddHeader("Authorization",
                            String.Format("Bearer {0}", CurrentUserHelper.Get.AccessToken.access_token));
                }

                IRestResponse<ResponseHelper> response = client.Execute<ResponseHelper>(request);

                rh = response.Data;
                return rh;

            }
            catch (Exception e)
            {
                rh.Message = e.Message;
                rh.Response = false;
                logger.Error(e.Message);
                return rh;
            }
        }
    }
}
