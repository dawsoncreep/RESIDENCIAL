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
                rh = Common.RestHelper.DoResourceServerPOST("/permission/InsertUpdate", model);
                logger.Debug("permission/InsertUpdate - response - " +
                    Newtonsoft.Json.JsonConvert.SerializeObject(rh));
               
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Delete_ErrorMessage,
                    Resources.Resources.Permission));
            }

            return rh;
        }

        public IEnumerable<Permission> GetAll()
        {
            var result = new List<Permission>();
            List<string> _roles = new List<string>();
            try
            {
                var resultreposnse = Common.RestHelper.DoResourceServerGET("/permission/GetAll");
                String json = Newtonsoft.Json.JsonConvert.SerializeObject(resultreposnse.Result);
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Permission>>(json);
               
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
                var resultreposnse = Common.RestHelper.DoResourceServerGET(String.Format("/permission/GetById/{0}", id));
                String json = Newtonsoft.Json.JsonConvert.SerializeObject(resultreposnse.Result);
                result =  Newtonsoft.Json.JsonConvert.DeserializeObject<Permission>(json);
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

                rh = Common.RestHelper.DoResourceServerPOST("/permission/Delete", GetById(id));
                logger.Debug("permission/Delete - response - " +
                    Newtonsoft.Json.JsonConvert.SerializeObject(rh));

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Delete_ErrorMessage,
                    Resources.Resources.Permission));
            }

            return rh;
        }
    }
}
