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
    public interface IExternalTypeService
    {
        IEnumerable<ExternalType> GetAll();
        ExternalType GetById(int id);
        ResponseHelper InsertUpdate(ExternalType model);
        ResponseHelper Delete(int id);
    }

    public class ExternalTypeService : IExternalTypeService
    {

        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();
            try
            {
                rh = RestHelper.DoResourceServerPOST("/externaltype/Delete", GetById(id));

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Delete_ErrorMessage,
                    Resources.Resources.ExternalType));
            }

            return rh;
        }

        public IEnumerable<ExternalType> GetAll()
        {
            var result = new List<ExternalType>();
            try
            {
                var resultreposnse = Common.RestHelper.DoResourceServerGET("/externaltype/GetAll");
                String json = Newtonsoft.Json.JsonConvert.SerializeObject(resultreposnse.Result);
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ExternalType>>(json);

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ExternalType GetById(int id)
        {
            var result = new ExternalType();

            try
            {
                var resultreposnse = Common.RestHelper.DoResourceServerGET(String.Format("/externaltype/GetById/{0}", id));
                String json = Newtonsoft.Json.JsonConvert.SerializeObject(resultreposnse.Result);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ExternalType>(json);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ResponseHelper InsertUpdate(ExternalType model)
        {
            var rh = new ResponseHelper();
            try
            {
                rh = Common.RestHelper.DoResourceServerPOST("/externaltype/InsertUpdate", model);
                logger.Debug("externaltype/InsertUpdate - response - " +
                    Newtonsoft.Json.JsonConvert.SerializeObject(rh));

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Insert_ErrorMessage,
                    Resources.Resources.ExternalType));
            }

            return rh;
        }
    }
}
