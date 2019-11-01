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
    public interface IBinnacleTypeService
    {
        IEnumerable<BinnacleType> GetAll();
        BinnacleType GetById(int id);
        ResponseHelper InsertUpdate(Tag model);
        ResponseHelper Delete(int id);
    }

    public class BinnacleTypeService : IBinnacleTypeService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        

        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();
            try
            {
                rh = RestHelper.DoResourceServerPOST("/BinnacleType/Delete", GetById(id));

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Delete_ErrorMessage,
                    Resources.Resources.BinnacleType));
            }

            return rh;
        }

        public IEnumerable<BinnacleType> GetAll()
        {
            var result = new List<BinnacleType>();
            try
            {
                var resultreposnse = Common.RestHelper.DoResourceServerGET("/BinnacleType/GetAll");
                String json = Newtonsoft.Json.JsonConvert.SerializeObject(resultreposnse.Result);
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BinnacleType>>(json);

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public BinnacleType GetById(int id)
        {
            var result = new BinnacleType();

            try
            {
                var resultreposnse = Common.RestHelper.DoResourceServerGET(String.Format("/BinnacleType/GetById/{0}", id));
                String json = Newtonsoft.Json.JsonConvert.SerializeObject(resultreposnse.Result);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<BinnacleType>(json);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ResponseHelper InsertUpdate(Tag model)
        {
            var rh = new ResponseHelper();
            try
            {
                rh = Common.RestHelper.DoResourceServerPOST("/BinnacleType/InsertUpdate", model);
                logger.Debug("tag/InsertUpdate - response - " +
                    Newtonsoft.Json.JsonConvert.SerializeObject(rh));

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Insert_ErrorMessage,
                    Resources.Resources.BinnacleType));
            }

            return rh;
        }
    }
}
