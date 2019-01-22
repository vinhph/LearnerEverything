using System;
using UsingAutofac.WebForm.Example.Bussiness;
using UsingAutofac.WebForm.Example.Models;

namespace UsingAutofac.WebForm.Example
{
    public partial class Default : System.Web.UI.Page
    {
        //setup autofac phai la public
        public ILog Log { get; set; }
        public IMyProduct MyProduct { get; set; }
        public IMyCart MyCart { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //ltrExample.Text = Log.PrintLog("ahihi");
            //ltrExample.Text = MyProduct.Logging("chihi");
            MyCart = CreatCart.Create(); //so you can not DI for Cart in global, it has been defined by CreatCart
            ltrExample.Text = MyCart.Logging("bhihi"); 
        }
    }
}