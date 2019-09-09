using Common;
using Model.Domain;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.InternalService
{
    public interface IExternalUserService 
    {
        IEnumerable<External> GetAll();
        External GetById(int id);
        ResponseHelper InsertUpdate(Object model);
        ResponseHelper Delete(int id);
    }

    public class ExternalUserService : IExternalUserService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public ResponseHelper Delete(int id)
        {
            return RestHelper.DoResourceServerPOST("/external/Delete", GetById(id));
        }

        public IEnumerable<External> GetAll()
        {
            var result = new List<External>();
            List<string> _roles = new List<string>();
            try
            {
                var resultreposnse = Common.RestHelper.DoResourceServerGET("/external/GetAll");
                String json = Newtonsoft.Json.JsonConvert.SerializeObject(resultreposnse.Result);
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<External>>(json);

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public External GetById(int id)
        {
            var result = new External();

            try
            {
                var resultreposnse = Common.RestHelper.DoResourceServerGET(String.Format("/external/GetById/{0}", id));
                String json = Newtonsoft.Json.JsonConvert.SerializeObject(resultreposnse.Result);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<External>(json);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;

        }

        public ResponseHelper InsertUpdate(Object model)
        {
            var rh = new ResponseHelper();
            try
            {
                rh = Common.RestHelper.DoResourceServerPOST("/external/InsertUpdate", model);
                logger.Debug("external/InsertUpdate - response - " +
                    Newtonsoft.Json.JsonConvert.SerializeObject(rh));

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Insert_ErrorMessage,
                    Resources.Resources.External));
            }

            return rh;

        }
    }
}
