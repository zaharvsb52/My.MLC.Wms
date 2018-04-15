using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;

namespace MLC.Wms.Bootstrap
{
    internal class DependencyResolverServiceLocator : IServiceLocator
    {
        public object GetService(Type serviceType)
        {
            return DependencyResolver.Current.GetService(serviceType);
        }

        public object GetInstance(Type serviceType)
        {
            return DependencyResolver.Current.GetService(serviceType);
        }

        public object GetInstance(Type serviceType, string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public TService GetInstance<TService>()
        {
            return (TService)DependencyResolver.Current.GetService(typeof(TService));
        }

        public TService GetInstance<TService>(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            throw new NotImplementedException();
        }
    }
}