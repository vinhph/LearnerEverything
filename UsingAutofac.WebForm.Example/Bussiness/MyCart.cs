using System.Web;
using Autofac;
using Autofac.Integration.Web;
using UsingAutofac.WebForm.Example.Models;

namespace UsingAutofac.WebForm.Example.Bussiness
{
    public interface IMyCart
    {
        string Logging(string input);
    }

    public class MyCart : IMyCart
    {
        public ILog Log { get; set; }
        public IMyRepository MyRepository { get; set; }
        public MyCart()
        {
            var cpa = (IContainerProviderAccessor)HttpContext.Current.ApplicationInstance;
            var cp = cpa.ContainerProvider;
            cp.RequestLifetime.InjectProperties(this);
        }

        public string Logging(string input)
        {
            string valueOfDb = MyRepository.Get();
            return Log.PrintLog(input + " - " + valueOfDb);
        }
    }
}