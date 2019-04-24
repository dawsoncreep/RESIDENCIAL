﻿using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Service.Providers
{
    public class JwtProvider
    {
        private static string _tokenUri;

        //default constructor
        public JwtProvider() { }

        public static JwtProvider Create(string tokenUri)
        {
            _tokenUri = tokenUri;
            return new JwtProvider();
        }

        public async Task<string> GetTokenAsync(string username, string password, string clientId, string deviceId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_tokenUri);
                client.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>("username", username),
                        new KeyValuePair<string, string>("password", password),
                        new KeyValuePair<string, string>("grant_type", "password"),
                        new KeyValuePair<string, string>("device_id", deviceId),
                        new KeyValuePair<string, string>("client_id", clientId),
                    });
                var response = await client.PostAsync("oauth2/token", content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    //return null if unauthenticated
                    return null;
                }
            }
        }

        public JObject DecodePayload(string token)
        {
            var parts = token.Split('.');
            var payload = parts[1];

            var payloadJson = Encoding.UTF8.GetString(Base64UrlDecode(payload));
            return JObject.Parse(payloadJson);
        }

        public ClaimsIdentity CreateIdentity(bool isAuthenticated, string userName, dynamic payload)
        {
            //decode the payload from token
            //in order to create a claim            
            string userId = payload.certserialnumber;
            //string userNamePayload = payload.name;
            string[] roles = null;
            string[] userPermission = null;

            if (payload.role != null)
            {
                var type = payload.role.GetType();
                //Newtonsoft.Json.Linq.JToken
                if (!(payload.role.GetType() == (typeof(Newtonsoft.Json.Linq.JArray))))
                {
                    JToken temp = payload.role.ToObject(typeof(Newtonsoft.Json.Linq.JToken));
                    roles = new string[] { payload.role.ToObject<string>() };
                }
                else
                {
                    Newtonsoft.Json.Linq.JArray temp = payload.role.ToObject(typeof(Newtonsoft.Json.Linq.JArray));

                    roles = temp.ToObject<string[]>();  //new string[] { payload.role.ToObject(typeof(Newtonsoft.Json.Linq.JArray)) };
                }
            }

            userPermission = GetUserPermissionFromPayLoad(payload);


            var jwtIdentity = new ClaimsIdentity(new JwtIdentity(
                isAuthenticated, userName, DefaultAuthenticationTypes.ApplicationCookie
                    ));

            //add user id
            jwtIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userName));
            jwtIdentity.AddClaim(new Claim(ClaimTypes.SerialNumber, userId));
            //add roles
            if (roles != null)
            {
                foreach (var role in roles)
                {
                    jwtIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
                }
            }
            //add Permissions
            if(userPermission != null)
            {
                foreach (var item in userPermission)
                {
                    jwtIdentity.AddClaim(new Claim("PermissionUser", item));
                }
            }


            return jwtIdentity;
        }

        private string[] GetUserPermissionFromPayLoad(dynamic payload)
        {
            if (payload.PermissionUser != null)
            {
                var type = payload.PermissionUser.GetType();
                //Newtonsoft.Json.Linq.JToken
                if (!(payload.PermissionUser.GetType() == (typeof(Newtonsoft.Json.Linq.JArray))))
                {
                    JToken temp = payload.PermissionUser.ToObject(typeof(Newtonsoft.Json.Linq.JToken));
                    return new string[] { payload.PermissionUser.ToObject<string>() };
                }
                else
                {
                    Newtonsoft.Json.Linq.JArray temp = payload.PermissionUser.ToObject(typeof(Newtonsoft.Json.Linq.JArray));
                    return temp.ToObject<string[]>();  
                }
            }
            else
            {
                return null;
            }
            
        }

        private byte[] Base64UrlDecode(string input)
        {
            var output = input;
            output = output.Replace('-', '+'); // 62nd char of encoding
            output = output.Replace('_', '/'); // 63rd char of encoding
            switch (output.Length % 4) // Pad with trailing '='s
            {
                case 0: break; // No pad chars in this case
                case 2: output += "=="; break; // Two pad chars
                case 3: output += "="; break; // One pad char
                default: throw new System.Exception("Illegal base64url string!");
            }
            var converted = Convert.FromBase64String(output); // Standard base64 decoder
            return converted;
        }
    }


    public class JwtIdentity : IIdentity
    {
        private bool _isAuthenticated;
        private string _name;
        private string _authenticationType;

        public JwtIdentity() { }
        public JwtIdentity(bool isAuthenticated, string name, string authenticationType)
        {
            _isAuthenticated = isAuthenticated;
            _name = name;
            _authenticationType = authenticationType;
        }
        public string AuthenticationType
        {
            get
            {
                return _authenticationType;
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return _isAuthenticated;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }
    }
}