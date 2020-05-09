﻿using System;
using System.Web;
using System.Web.Security;

namespace Order_Application_Admin
{
    public partial class SignOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("~/SignIn.aspx");
        }
    }
}