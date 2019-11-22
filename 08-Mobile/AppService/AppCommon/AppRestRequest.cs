using System;
using System.Collections.Generic;
using System.Text;



namespace AppService.AppCommon
{
    

    public static class AppRestRequest
    {
        private const String RESOURCE_SERVICE_URL = "http://localhost:8128";
        private const String AUTH_SERVICE_URL = "http://localhost:23218";
        private const String AUDIENCE_ID = "86c6ee593e144cd197611a6da15684b0";





        public static Common.ResponseHelper Login(Models.LoginModel login, String Url)
        {
            var rh = new Common.ResponseHelper();

            try
            {
                var client = new RestSharp.RestClient(AUTH_SERVICE_URL);

                var request = new RestSharp.RestRequest(Url, RestSharp.Method.POST);


                request.Parameters.Add(new RestSharp.Parameter
                {
                    Name = "username",
                    ContentType = "application/x-www-form-urlencoded",
                    DataFormat = RestSharp.DataFormat.Json,
                    Type = RestSharp.ParameterType.GetOrPost,
                    Value = login.username,
                    
                });

                request.Parameters.Add(new RestSharp.Parameter
                {
                    Name = "password",
                    ContentType = "application/x-www-form-urlencoded",
                    DataFormat = RestSharp.DataFormat.Json,
                    Type = RestSharp.ParameterType.GetOrPost,
                    Value = login.password,

                });

                request.Parameters.Add(new RestSharp.Parameter
                {
                    Name = "grant_type",
                    ContentType = "application/x-www-form-urlencoded",
                    DataFormat = RestSharp.DataFormat.Json,
                    Type = RestSharp.ParameterType.GetOrPost,
                    Value = login.grant_type,

                });

                request.Parameters.Add(new RestSharp.Parameter
                {
                    Name = "client_id",
                    ContentType = "application/x-www-form-urlencoded",
                    DataFormat = RestSharp.DataFormat.Json,
                    Type = RestSharp.ParameterType.GetOrPost,
                    Value = login.client_id,

                });



                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                RestSharp.IRestResponse<Common.ResponseHelper> response =
                    client.Execute<Common.ResponseHelper>(request);

                if (response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                {
                    if (!String.IsNullOrEmpty(response.Content))
                    {
                        rh.Result = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.
                            TokenResultHelper>(response.Content);

                        rh.SetResponse(true, Resources.Resources.Process_OkMessage);
                    }
                }
                else
                {
                    var dRes = Newtonsoft.Json.JsonConvert.
                        DeserializeObject <Dictionary<String, String>>(response.Content);

                    rh.Message = dRes["error_description"];
                    rh.SetResponse(false);
                }
                return rh;

            }
            catch (Exception e)
            {
                rh.Message = String.Format(Resources.Resources.Process_ErrorMessage);
                rh.Response = false;
                return rh;
            }

        }


        public static Common.ResponseHelper DoResourceServerPOST(String Url, Object data = null, String token = null)
        {
            var rh = new Common.ResponseHelper();

            try
            {
                var client = new RestSharp.RestClient(RESOURCE_SERVICE_URL);

                var request = new RestSharp.RestRequest(Url, RestSharp.Method.POST);

                request.Parameters.Add(new RestSharp.Parameter
                {
                    Name = "model",
                    ContentType = "application/json",
                    DataFormat = RestSharp.DataFormat.Json,
                    Type = RestSharp.ParameterType.RequestBody,
                    Value = data
                });

                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                if(!String.IsNullOrEmpty(token))
                request.AddHeader("Authorization",
                        String.Format("Bearer {0}", token));

                RestSharp.IRestResponse<Common.ResponseHelper> response = 
                    client.Execute<Common.ResponseHelper>(request);

                if (response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                {
                    rh = response.Data;

                }
                else
                {
                    rh.Message = response.ErrorMessage ?? response.ErrorException.Message;
                    rh.SetResponse(false);
                }
                return rh;

            }
            catch (Exception e)
            {
                rh.Message = String.Format(Resources.Resources.Process_ErrorMessage);
                rh.Response = false;
                return rh;
            }
        }


        public static Common.ResponseHelper DoResourceServerGET(String Url, string token = null)
        {
            var rh = new Common.ResponseHelper();

            try
            {
                var client = new RestSharp.RestClient(RESOURCE_SERVICE_URL);

                var request = new RestSharp.RestRequest(Url, RestSharp.Method.GET);

                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                if (!String.IsNullOrEmpty(token))
                    request.AddHeader("Authorization",
                        String.Format("Bearer {0}", token));

                RestSharp.IRestResponse<Common.ResponseHelper> response = 
                    client.Execute<Common.ResponseHelper>(request);

                if (response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                {
                    rh = response.Data;
                }
                else
                {
                    rh.Message = response.ErrorMessage ?? response.ErrorException.Message;
                    rh.SetResponse(false);
                }

                return rh;

            }
            catch (Exception e)
            {
                rh.Message = String.Format(Resources.Resources.Process_ErrorMessage);
                rh.SetResponse(false);
                return rh;
            }
        }

    }
}
