[assembly: WebActivator.PostApplicationStartMethod(typeof(Api.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace Api.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using Prueba.Negocio.Interfaces;
    using Prueba.Negocio;        
    using Prueba.Persistencia.Interfaces;
    using Prueba.Persistencia.Base;
    using Prueba.Persistencia.Repositorios;

    public class SimpleInjectorWebApiInitializer
    {
        public static void Initialize()
        {
            var container = new Container();            
            container.Options.DefaultScopedLifestyle = new SimpleInjector.Lifestyles.AsyncScopedLifestyle();
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            #region Negocio
            container.Register<INegocioFactura, NegocioFactura>(Lifestyle.Scoped);
            container.Register<INegocioProducto, NegocioProducto>(Lifestyle.Scoped);      

            #endregion

            #region Datos

            container.Register(typeof(IRepositorioBase<>), typeof(RepositorioBase<>)); 
            container.Register<IRepositorioFactura, RepositorioFactura>(Lifestyle.Scoped);
            container.Register<IRepositorioProducto, RepositorioProducto>(Lifestyle.Scoped);

            #endregion
        }
    }
}