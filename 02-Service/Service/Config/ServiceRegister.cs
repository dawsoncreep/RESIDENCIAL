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
            container.Register<IRepository<Permission>>((x) => new Repository<Permission>(ambientDbContextLocator));
            container.Register<IRepository<PermissionUser>>((x) => new Repository<PermissionUser>(ambientDbContextLocator));
            container.Register<IRepository<PermissionRole>>((x) => new Repository<PermissionRole>(ambientDbContextLocator));
            container.Register<IRepository<EventType>>((x) => new Repository<EventType>(ambientDbContextLocator));
            container.Register<IRepository<Event>>((x) => new Repository<Event>(ambientDbContextLocator));
            container.Register<IRepository<LocationType>>((x) => new Repository<LocationType>(ambientDbContextLocator));
            container.Register<IRepository<Location>>((x) => new Repository<Location>(ambientDbContextLocator));
            container.Register<IRepository<LocationUser>>((x) => new Repository<LocationUser>(ambientDbContextLocator));
            container.Register<IRepository<External>>((x) => new Repository<External>(ambientDbContextLocator));
            container.Register<IRepository<ExternalType>>((x) => new Repository<ExternalType>(ambientDbContextLocator));
            container.Register<IRepository<ApplicationParameters>>((x) => new Repository<ApplicationParameters>(ambientDbContextLocator));
            container.Register<IRepository<Tag>>((x) => new Repository<Tag>(ambientDbContextLocator));

            #endregion

            #region ExternalServices
            container.Register<IAPIUserService, APIUserService>();
            container.Register<IAPIRoleService, APIRoleService>();
            container.Register<IAPIPermissionService, APIPermissionService>();
            container.Register<IAPIPermissionUserService, APIPermissionUserService>();
            container.Register<IAPIEventTypeService, APIEventTypeService>();
            container.Register<IAPIEventService, APIEventService>();
            container.Register<IAPILocationTypeService, APILocationTypeService>();
            container.Register<IAPILocationService, APILocationService>();
            container.Register<IAPIPermissionRoleService, APIPermissionRoleService>();
            container.Register<IAuthorizationServerService, AuthorizationServerService>();
            container.Register<IAPILocationUserService, APILocationUserService>();
            container.Register<IAPIExternalUserService, APIExternalUserService>();
            container.Register<IAPIExternalTypeService, APIExternalTypeService>();
            container.Register<IAPIApplicationParametersService, APIApplicationParametersService>();
            container.Register<IAPITagService, APITagService>();


            #endregion

            #region InternalServices
            container.Register<IUserService, UserService>();
            container.Register<IRoleService, RoleService>();
            container.Register<IPermissionService, PermissionService>();
            container.Register<IEventTypeService, EventTypeService>();
            container.Register<IEventService, EventService>();
            container.Register<ILocationTypeService, LocationTypeService>();
            container.Register<ILocationService, LocationService>();
            container.Register<IPermissionUserService, PermissionUserService>();
            container.Register<IPermissionRoleService, PermissionRoleService>();
            container.Register<ILocationUserService, LocationUserService>();
            container.Register<IExternalUserService, ExternalUserService>();
            container.Register<IExternalTypeService, ExternalTypeService>();
            container.Register<IApplicationParametersService, ApplicationParametersService>();
            container.Register<ITagService, TagService>();

            #endregion
        }
    }
}
