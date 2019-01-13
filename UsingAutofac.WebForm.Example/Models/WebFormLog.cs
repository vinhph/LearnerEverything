using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsingAutofac.WebForm.Example.Models
{
    public class WebFormLog : ILog
    {
        public string PrintLog(string message)
        {
            return "Print: " + message;
        }
    }
}