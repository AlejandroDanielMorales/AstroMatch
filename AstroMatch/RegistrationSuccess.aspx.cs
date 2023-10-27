using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using Management;

namespace AstroMatch
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Domain;
    using Management;

    public partial class RegistrationSuccess : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserManager userManager = new UserManager();
                var users = userManager.GetAllUsers();
                rptUsers.DataSource = users;
                rptUsers.DataBind();
            }
        }
    }
}