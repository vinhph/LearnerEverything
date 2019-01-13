using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using UsingAutofac.MVC.Example.Models;

namespace UsingAutofac.MVC.Example
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //setup autofac
        static IContainerProvider _containerProvider;
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //setup autofac
            var builder = new ContainerBuilder();
            //phai co dang ky toan bo controller cua project nay
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<MVCLog>().As<ILog>();
            var container = builder.Build();
            //var output = container.Resolve<ILog>();
            //string abc = output.PrintLog("abc");
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
