using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace UsingAutofac
{
    class Program
    {
        static IGigyaAppSetting _gigyaAppSetting;
        private static IContainer Container { get; set; }
        
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            //test1
            //builder.RegisterType<ConsoleOutput>().As<IOutput>();
            //builder.RegisterType<TodayWriter>().As<IDateWriter>();
            //Container = builder.Build();
            //var scope = Container.BeginLifetimeScope();            
            //var writer = scope.Resolve<IDateWriter>();           
            //writer.WriteDate();

            //test2
            builder.RegisterModule(new CarTransportModule());
            var container = builder.Build();
            var output = container.Resolve<IOutput>();
            output.Write("abc");

            Console.Read();
        }

        
    }
}
