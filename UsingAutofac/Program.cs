using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using UsingAutofac.Models;

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
            //builder.RegisterModule(new CarTransportModule());
            //var container = builder.Build();
            //var output = container.Resolve<IOutput>();
            //output.Write("abc");

            // Register expressions that execute to create objects...
            //builder.Register(c => new ConfigReader("mysection")).As<IConfigReader>();
            //var container = builder.Build();
            //// Now you can resolve services using Autofac. For example,
            //// this line will execute the lambda expression registered
            //// to the IConfigReader service.
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var reader = scope.Resolve<IConfigReader>();
            //    reader.Print();
            //}

            //Register by Type
            //builder.RegisterType<MyComponent>();
            //builder.RegisterType<ConsoleLogger>().As<ILogger>();
            //var container = builder.Build();
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var component = scope.Resolve<MyComponent>();               
            //}


            //Specifying a Constructor
            //builder.RegisterType<MyComponent>()
            //    .UsingConstructor(typeof(ILogger), typeof(IConfigReader));
            //builder.RegisterType<ConsoleLogger>().As<ILogger>();
            ////ep dung constructor kieu 2 param, nhung IConfigReader khong co nen se loi
            ////neu muon chay dung can dang ky IConfigReader:
            ////builder.Register(c => new ConfigReader("mysection")).As<IConfigReader>();
            //var container = builder.Build();
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var component = scope.Resolve<MyComponent>();
            //    component.Print();
            //}

            //Instance Components
            var output = new StringWriter();
            builder.RegisterInstance(output)
                   .As<TextWriter>()
                   .ExternallyOwned();
            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var reader = scope.Resolve<TextWriter>();
                reader.Print();
            }
            Console.Read();
        }

        
    }
}
