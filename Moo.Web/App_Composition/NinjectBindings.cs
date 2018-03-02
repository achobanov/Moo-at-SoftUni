using Moo.Domain.Services;
using Moo.Entities.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moo.AppComposition
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IHomeService>().To<HomeService>();
        }
    }
}