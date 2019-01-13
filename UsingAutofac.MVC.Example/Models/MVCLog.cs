using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsingAutofac.MVC.Example.Models
{
    public class MVCLog : ILog
    {
        public string PrintLog(string message)
        {
            return "Print: " + message;
        }
    }
}