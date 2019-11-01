using Common;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ExternalService
{
    public interface IAPIExternalBinnacleService
    {
        IEnumerable<ExternalBinnacle> GetAll();
        ResponseHelper<ExternalBinnacle> GetById(int id);
        ResponseHelper InsertUpdate(ExternalBinnacle model);
        ResponseHelper Delete(int id);
    }

    public class APIExternalBinnacleService : IAPIExternalBinnacleService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<ExternalBinnacle> _ExternalBinnacleRepo;
        private readonly IRepository<BinnacleType> _binnacleTypeRepo;
        private readonly IRepository<External> _externalRepo;
        private readonly IRepository<ExternalBinnaclePhoto> _externalBinnaclePhotoRepo;
        private readonly IRepository<BinnaclePhotoType> _binnaclePhotoTypeRepo;



        public APIExternalBinnacleService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<ExternalBinnacle> ExternalBinnacleRepo,
            IRepository<BinnacleType> binnacleType,
            IRepository<External> external,
            IRepository<ExternalBinnaclePhoto> externalBinnaclePhotoRepo,
            IRepository<BinnaclePhotoType> binnaclePhotoTypeRepo
            
            )
        {
            _binnaclePhotoTypeRepo = binnaclePhotoTypeRepo;
            _dbContextScopeFactory = dbContextScopeFactory;
            _ExternalBinnacleRepo = ExternalBinnacleRepo;
            _binnacleTypeRepo = binnacleType;
            _externalRepo = external;
            _externalBinnaclePhotoRepo = externalBinnaclePhotoRepo;
        }

        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var model = _ExternalBinnacleRepo.SingleOrDefault(x => x.Id == id);
                    _ExternalBinnacleRepo.Delete(model);

                    ctx.SaveChanges();
                }
                rh.SetResponse(true, String.Format(Resources.Resources.Delete_OkMessage,
                      Resources.Resources.ExternalBinnacle));
                return rh;
            }
            catch (Exception e)
            {   
                logger.Error(e.Message);
                rh.SetResponse(true, String.Format(Resources.Resources.Delete_ErrorMessage,
                      Resources.Resources.ExternalBinnacle));
                return rh;
            }
        }

        public IEnumerable<ExternalBinnacle> GetAll()
        {
            var result = new List<ExternalBinnacle>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = new List<ExternalBinnacle>(_ExternalBinnacleRepo.GetAll(
                        et => et.BinnacleType,
                        e => e.External,
                        bp => bp.ExternalBinnaclePhoto
                        ));

                    result.ForEach(fr =>
                    {
                        fr.ExternalBinnaclePhoto.ForEach(fr2 =>
                        {
                            fr2 = _externalBinnaclePhotoRepo.Find(f => f.Id == fr2.Id, g => g.BinnaclePhotoType).SingleOrDefault();
                        });
                    });

                }

                return result;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return result;
            }
        }

        public ResponseHelper<ExternalBinnacle> GetById(int id)
        {
            var rh = new ResponseHelper<ExternalBinnacle>();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {

                    var result = _ExternalBinnacleRepo.SingleOrDefault(s => s.Id == id,
                        et => et.BinnacleType,
                        e => e.External,
                        bp => bp.ExternalBinnaclePhoto);


                    result.ExternalBinnaclePhoto.ForEach(fr2 =>
                    {
                        fr2 = _externalBinnaclePhotoRepo.Find(f => f.Id == fr2.Id, g => g.BinnaclePhotoType).SingleOrDefault();
                    });
                    

                    rh.Result = result;

                }



                rh.SetResponse(true);
                return rh;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false);
                return rh;
            }
        }

        public ResponseHelper InsertUpdate(ExternalBinnacle model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var modelById = _ExternalBinnacleRepo.Find(x =>
                        x.Id == model.Id
                    ).SingleOrDefault();

                    if (modelById == null)
                    {
                        model.External = _externalRepo.
                            Find(f => f.Id == model.External.Id).SingleOrDefault();

                        model.BinnacleType = _binnacleTypeRepo.
                            Find(f => f.Id == model.BinnacleType.Id).SingleOrDefault();

                        model.ExternalBinnaclePhoto.ForEach(fr =>
                        {
                            fr.BinnaclePhotoType = _binnaclePhotoTypeRepo.Find(f => f.Id == fr.BinnaclePhotoType.Id).SingleOrDefault();
                        });



                        model.UpdatedAt = null;
                        model.CreatedAt = DateTime.Now;
                        model.CreatedBy = CurrentUserHelper.Get.UserId;
                         

                        _ExternalBinnacleRepo.Insert(model);


                    }
                    else
                    {
                        modelById.Id = model.Id;
                        modelById.ExitDate = model.ExitDate;
                        modelById.UpdatedAt = DateTime.Now;
                        modelById.UpdatedBy = CurrentUserHelper.Get.UserId;
                        modelById.SessionId = model.SessionId;

                        _ExternalBinnacleRepo.Update(modelById);
                    }

                    ctx.SaveChanges();
                    rh.SetResponse(true, String.Format(Resources.Resources.Insert_OkMessage,
                          Resources.Resources.ExternalBinnacle));
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, String.Format(Resources.Resources.Insert_ErrorMessage,
                          Resources.Resources.ExternalBinnacle));
            }

            return rh;
        }
    }
}
