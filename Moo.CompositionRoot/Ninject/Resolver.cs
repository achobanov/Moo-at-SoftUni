using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Moo.CompositionRoot.Ninject
{
    public class NinjectResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectResolver()
        {
            this._kernel = new StandardKernel(new Bindings());
        }

        public object GetService(Type serviceType)
        {
            return this._kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this._kernel.GetAll(serviceType);
        }
    }
}