using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsingAutofac.WebForm.Example.Bussiness
{
    public class CreatCart
    {
        public static IMyCart Create()
        {
            return new MyCart();
        }
    }
}