using LightInject;
using Model.Auth;
using Model.Domain;
using Persistence.DbContextScope;
using Persistence.Repository;
using Service.ExternalService;
using Service.InternalService;

namespace Service.Config
{
    public class ServiceRegister : ICompositionRoot
    {               
        public void Compose(IServiceRegistry container)
        {
            var ambientDbContextLocator = new AmbientDbContextLocator();

            container.Register<IDbContextScopeFactory>((x) => new DbContextScopeFactory(null));
            container.Register<IAmbientDbContextLocator, AmbientDbContextLocator>(new PerScopeLifetime());

            #region Repositorios
            container.Register<IRepository<ApplicationUser>>((x) => new Repository<ApplicationUser>(ambientDbContextLocator));
            container.Register<IRepository<ApplicationRole>>((x) => new Repository<ApplicationRole>(ambientDbContextLocator));
            container.Register<IRepository<Audience>>((x) => new Repository<Audience>(ambientDbContextLocator));

            #endregion

            #region ExternalServices
            container.Register<IAPIUserService, APIUserService>();
            container.Register<IAPIRoleService, APIRoleService>();
            container.Register<IAuthorizationServerService, AuthorizationServerService>();
            #endregion

            #region InternalServices
            container.Register<IUserService, UserService>();
            container.Register<IRoleService, RoleService>();
            #endregion
        }
    }
}
