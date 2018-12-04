using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace UsingAutofac
{
    public class GigyaAppSettingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new GigyaAppSetting()).As<IGigyaAppSetting>();
            var container = builder.Build();
        }
    }
}
