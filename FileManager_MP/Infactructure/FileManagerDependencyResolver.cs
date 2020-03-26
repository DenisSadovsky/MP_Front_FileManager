using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Unity;

namespace FileManager_MP.Infactructure
{
    public class FileManagerDependencyResolver : IDependencyResolver
    {
        private IUnityContainer _unityContainer;

        public FileManagerDependencyResolver(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer; 
        }
        public object GetService(Type serviceType)
        {
            try
            {

                return _unityContainer.Resolve(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {

                return _unityContainer.ResolveAll(serviceType);
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }
    }
}