using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace UsingAutofac
{
    public class CarTransportModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ConsoleOutput()).As<IOutput>();            
        }
    }
}
