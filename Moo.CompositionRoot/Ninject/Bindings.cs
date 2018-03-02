using Moo.Data.UnitOfWork;
using Moo.Domain.DataInterfaces;
using Moo.Domain.Services;
using Moo.Entities.Interfaces.Domain;
using Ninject.Modules;

namespace Moo.CompositionRoot.Ninject
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IHomeService>().To<HomeService>();
            Bind<IUnitOfWork>().To<Unit>();
        }
    }
}