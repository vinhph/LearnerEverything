using Autofac;
using Autofac.Integration.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using UsingAutofac.WebForm.Example.Bussiness;
using UsingAutofac.WebForm.Example.Models;

namespace UsingAutofac.WebForm.Example
{
    //setup autofac phai ke thua IContainerProviderAccessor
    public class Global : System.Web.HttpApplication, IContainerProviderAccessor
    {
        //setup autofac
        static IContainerProvider _containerProvider;
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }
        protected void Application_Start(object sender, EventArgs e)
        {
            //setup autofac
            var builder = new ContainerBuilder();
            builder.RegisterType<WebFormLog>().As<ILog>();
            builder.RegisterType<MyProduct>().As<IMyProduct>();
            builder.RegisterType<MyRepository>().As<IMyRepository>();
            // Once you're done registering things, set the container
            // provider up with your registrations.
            _containerProvider = new ContainerProvider(builder.Build());
        }
    }
}