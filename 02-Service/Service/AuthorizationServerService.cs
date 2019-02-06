using Common;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Model.AuthorizationServer;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Service
{

    public interface IAuthorizationServerService
    {
        IEnumerable<Audience> GetAll();
        Audience Get(String id);
        Audience InsertOrUpdate(AudienceForSuscribe model);
        ResponseHelper Delete(String id);

    }
    public class AuthorizationServerService : IAuthorizationServerService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Audience> _authorizationServerRepository;

        public AuthorizationServerService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Audience> authorizationServerRepository
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _authorizationServerRepository = authorizationServerRepository;
        }

        public ResponseHelper Delete(String id)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var model = _authorizationServerRepository.SingleOrDefault(x => x.ClientId == id);
                    _authorizationServerRepository.Delete(model);

                    ctx.SaveChanges();
                    rh.SetResponse(true);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return rh;
        }

        public Audience Get(String id)
        {
            var result = new Audience();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    result = _authorizationServerRepository.SingleOrDefault(x => x.ClientId == id);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public IEnumerable<Audience> GetAll()
        {
            throw new NotImplementedException();
        }

        public Audience InsertOrUpdate(AudienceForSuscribe model)
        {
            var rh = new ResponseHelper();
            Audience audienceResponce = new Audience();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {

                    if (String.IsNullOrEmpty(model.ClientId))
                    {
                        var key = new byte[32];
                        RNGCryptoServiceProvider.Create().GetBytes(key);
                        var base64Secret = TextEncodings.Base64Url.Encode(key);


                        audienceResponce.Base64Secret = base64Secret;
                        audienceResponce.ClientId = Guid.NewGuid().ToString("N");
                        audienceResponce.Name = model.Name;

                        _authorizationServerRepository.Insert(audienceResponce);
                    }
                    else
                    {

                        audienceResponce.Base64Secret = model.Base64Secret;
                        audienceResponce.ClientId = model.ClientId;
                        audienceResponce.Name = model.Name;

                        _authorizationServerRepository.Update(audienceResponce);
                    }

                    ctx.SaveChanges();
                    rh.SetResponse(true);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return audienceResponce;
        }
    }
}
