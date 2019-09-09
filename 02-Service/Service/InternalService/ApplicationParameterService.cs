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
    public interface IApplicationParametersService
    {
        IEnumerable<ApplicationParameters> GetAll();
        ApplicationParameters GetById(int id);
        ApplicationParameters GetByKey(String key);
        ResponseHelper InsertUpdate(ApplicationParameters model);
        ResponseHelper Delete(int id);
    }

    public class ApplicationParametersService : IApplicationParametersService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();
            try
            {
                rh = RestHelper.DoResourceServerPOST("/applicationParameters/Delete", GetById(id));

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Delete_ErrorMessage,
                    Resources.Resources.ApplicationParameters));
            }

            return rh;
        }

        public IEnumerable<ApplicationParameters> GetAll()
        {
            var result = new List<ApplicationParameters>();
            try
            {
                var resultreposnse = Common.RestHelper.DoResourceServerGET("/applicationParameters/GetAll");
                String json = Newtonsoft.Json.JsonConvert.SerializeObject(resultreposnse.Result);
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ApplicationParameters>>(json);

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ApplicationParameters GetById(int id)
        {
            var result = new ApplicationParameters();

            try
            {
                var resultreposnse = Common.RestHelper.DoResourceServerGET(String.Format("/applicationParameters/GetById/{0}", id));
                String json = Newtonsoft.Json.JsonConvert.SerializeObject(resultreposnse.Result);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ApplicationParameters>(json);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ApplicationParameters GetByKey(string key)
        {
            var result = new ApplicationParameters();

            try
            {
                var resultreposnse = Common.RestHelper.DoResourceServerGET(String.Format("/applicationParameters/GetByKey/{0}", key));
                String json = Newtonsoft.Json.JsonConvert.SerializeObject(resultreposnse.Result);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ApplicationParameters>(json);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ResponseHelper InsertUpdate(ApplicationParameters model)
        {
            var rh = new ResponseHelper();
            try
            {
                rh = Common.RestHelper.DoResourceServerPOST("/applicationParameters/InsertUpdate", model);
                logger.Debug("externaltype/InsertUpdate - response - " +
                    Newtonsoft.Json.JsonConvert.SerializeObject(rh));

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Insert_ErrorMessage,
                    Resources.Resources.ApplicationParameters));
            }

            return rh;
        }
    }
}
