using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsingAutofac.WebForm.Example.Models
{
    public class MyRepository : IMyRepository
    {
        public string Get()
        {
            return "This is value of Database";
        }
    }
}