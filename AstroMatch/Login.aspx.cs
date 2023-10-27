using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Domain;
using Management;

namespace AstroMatch
{
    public partial class Login : System.Web.UI.Page
    {


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtemail.Text;
            string password = txtPassword.Text;
            UserManager uManager = new UserManager();


            if (uManager.VerificarCredenciales(email, password))
            {
                User user = uManager.GetUserByEmail(email);
                Session.Add("UserLoged", user);
                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
   
    }
}