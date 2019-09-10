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
    public interface ITagService
    {
        IEnumerable<Tag> GetAll();
        Tag GetById(int id);
        ResponseHelper InsertUpdate(Tag model);
        ResponseHelper Delete(int id);
    }

    public class TagService : ITagService
    {

        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();
            try
            {
                rh = RestHelper.DoResourceServerPOST("/tag/Delete", GetById(id));

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Delete_ErrorMessage,
                    Resources.Resources.Tag));
            }

            return rh;
        }

        public IEnumerable<Tag> GetAll()
        {
            var result = new List<Tag>();
            try
            {
                var resultreposnse = Common.RestHelper.DoResourceServerGET("/tag/GetAll");
                String json = Newtonsoft.Json.JsonConvert.SerializeObject(resultreposnse.Result);
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Tag>>(json);

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public Tag GetById(int id)
        {
            var result = new Tag();

            try
            {
                var resultreposnse = Common.RestHelper.DoResourceServerGET(String.Format("/tag/GetById/{0}", id));
                String json = Newtonsoft.Json.JsonConvert.SerializeObject(resultreposnse.Result);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<Tag>(json);
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
                rh = Common.RestHelper.DoResourceServerPOST("/tag/InsertUpdate", model);
                logger.Debug("tag/InsertUpdate - response - " +
                    Newtonsoft.Json.JsonConvert.SerializeObject(rh));

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Insert_ErrorMessage,
                    Resources.Resources.Tag));
            }

            return rh;
        }
    }
}
