﻿using Common;
using Model.Auth;
using Model.Custom;
using NLog;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.InternalService
{
    public interface IUserService
    {
        IEnumerable<UserForGridView> GetAll();
        UserForGridView Get(string userName);
        UserForGridView GetById(string Id);
        ResponseHelper InsertUpdate(ApplicationUser model);
        ResponseHelper DeleteUserRole(ApplicationUserRole model);
    }

    public class UserService : IUserService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IRoleService _roleService = DependecyFactory.GetInstance<IRoleService>();

        public ResponseHelper DeleteUserRole(ApplicationUserRole model)
        {
            var rh = new ResponseHelper();
            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest("/userRole/Delete", Method.POST);

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

        public UserForGridView Get(string userName)
        {
            var result = new UserForGridView();
            List<ApplicationRole> _roles = new List<ApplicationRole>();
            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);
                
                var request = new RestRequest(String.Format("/user/Get/{0}", userName), Method.GET);

                // easily add HTTP Headers
                //En caso de requerir autenticación hay que extraer el token de la cookie.
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                    
                IRestResponse response = client.Execute(request);
                var responseDes = Newtonsoft.Json.JsonConvert.DeserializeObject<ApplicationUser>(response.Content);

                foreach (var item in responseDes.Roles)
                {
                    _roles.Add(_roleService.Get(new Guid(item.RoleId)));
                }

                result = new UserForGridView
                {
                    Email = responseDes.Email,
                    Id = responseDes.Id,
                    Roles = _roles,
                    UserName = responseDes.UserName,
                    LastName = responseDes.LastName,
                    MotherSurname = responseDes.MotherSurname,
                    Name = responseDes.Name
                };

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public IEnumerable<UserForGridView> GetAll()
        {
            var result = new List<UserForGridView>();

            try
            {

                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest("/user/GetAll", Method.GET);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                IRestResponse responseUsers = client.Execute(request);
                var responseUsersArray = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ApplicationUser>>(responseUsers.Content);

                request = new RestRequest("/role/GetAll", Method.GET);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                    IRestResponse responseRoles = client.Execute(request);
                var responseRolesArray = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ApplicationRole>>(responseRoles.Content);

                result = (
                    from u in responseUsersArray
                    select new UserForGridView
                    {
                        Id = u.Id,
                        Email = u.Email,
                        UserName = u.UserName,
                        LastName = u.LastName,
                        MotherSurname = u.MotherSurname,
                        Name = u.Name,
                        Roles = 
                            (from r in responseRolesArray
                            join r2 in u.Roles
                            on r.Id equals r2.RoleId
                            select r   
                        ).ToList()
                    }
                ).ToList();
                
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public UserForGridView GetById(string Id)
        {
            var result = new UserForGridView();
            List<ApplicationRole> _roles = new List<ApplicationRole>();

            try
            {
                var resultreposnse = Common.RestHelper.DoResourceServerGET(String.Format("/user/GetById/{0}", Id));
                String json = Newtonsoft.Json.JsonConvert.SerializeObject(resultreposnse.Result);
                var responseDes = Newtonsoft.Json.JsonConvert.DeserializeObject<ApplicationUser>(json);


                foreach (var item in responseDes.Roles)
                {
                    _roles.Add(_roleService.Get(new Guid(item.RoleId)));
                }

                result = new UserForGridView
                {
                    Email = responseDes.Email,
                    Id = responseDes.Id,
                    Roles = _roles,
                    UserName = responseDes.UserName,
                    LastName = responseDes.LastName,
                    MotherSurname = responseDes.MotherSurname,
                    Name = responseDes.Name
                };
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result; 
        }

        public ResponseHelper InsertUpdate(ApplicationUser model)
        {
            var rh = new ResponseHelper();
            try
            {
                var client = new RestClient(Parameters.resourceServerUrl);

                var request = new RestRequest("/user/InsertUpdate", Method.POST);

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
