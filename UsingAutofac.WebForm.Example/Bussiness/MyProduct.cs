using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsingAutofac.WebForm.Example.Models;

namespace UsingAutofac.WebForm.Example.Bussiness
{
    public interface IMyProduct
    {
        string Logging(string input);
    }

    public class MyProduct : IMyProduct
    {
        public ILog Log { get; set; }

        public MyProduct(ILog log)
        {
            Log = log;
        }

        public string Logging(string input)
        {            
            return Log.PrintLog(input);
        }
    }
}