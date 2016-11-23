using System;
using System.Collections.Generic;
using System.Web.Mvc;
using LinkManager.Domain.DAL.Abstract;
using LinkManager.Domain.DAL.Concrete;
using LinkManager.Domain.Entities;
using Moq;
using Ninject;
using Ninject.Web.Common;

namespace LinkManager.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<ILinkRepository>().To<FakeLinkRepository>().InSingletonScope();
        }
    }
}