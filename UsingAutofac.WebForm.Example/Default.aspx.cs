using System;
using UsingAutofac.WebForm.Example.Models;

namespace UsingAutofac.WebForm.Example
{
    public partial class Default : System.Web.UI.Page
    {
        //setup autofac phai la public
        public ILog _log { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ltrExample.Text = _log.PrintLog("ahihi");
        }
    }
}