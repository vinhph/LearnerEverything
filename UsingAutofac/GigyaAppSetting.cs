using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingAutofac
{
    public interface IGigyaAppSetting
    {
        string GigyaApiKey { get; }
    }
    public class GigyaAppSetting : IGigyaAppSetting
    {
        public string GigyaApiKey { get; private set; }

        public GigyaAppSetting()
        {
            GigyaApiKey = "vịnh";
        }
    }
}
