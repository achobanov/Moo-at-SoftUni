using Moo.Data.UnitOfWork;
using Moo.Domain.DataInterfaces;
using Moo.Domain.OpponentPlayer;
using Moo.Domain.IdentityProviders;
using Moo.Domain.Services;
using Moo.Entities.Interfaces;
using Ninject.Modules;

namespace Moo.CompositionRoot.Ninject
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<Unit>();

            Bind<IAccountService>().To<AccountService>();
            Bind<IAuthenticationProvider>().To<AuthenitcationProvider>();
            Bind<IAuthorizationProvider>().To<AuthorizationService>();
            Bind<IGameService>().To<GameService>();

            Bind<Opponent>().To<Opponent>();
            Bind<Tools>().To<Tools>();  
        }
    }
}