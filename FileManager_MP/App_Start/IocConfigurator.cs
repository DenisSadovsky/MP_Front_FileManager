using System.Web.Mvc;
using FileManager_MP.Infactructure;
using FileManager_MP.Services;
using Unity;

namespace FileManager_MP.App_Start
{
    public static class IocConfigurator
    {
        public static void ConfigureIocContainer()
        {
            IUnityContainer container = new UnityContainer();

            RegisterServices(container);

            DependencyResolver.SetResolver(new FileManagerDependencyResolver(container));
        }

        private static void RegisterServices(IUnityContainer container)
        {
            container.RegisterType<IAccountServiceProvider, AccountServiceProvider>();
            container.RegisterType<IFileDirectoryServiceProvider, FileDirectoryServiceProvider>();
        }
    }
}