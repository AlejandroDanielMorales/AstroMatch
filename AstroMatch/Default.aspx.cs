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
    public partial class Default : System.Web.UI.Page
    {
        public User currentUser;

        public UrlImage ProfilePhoto;
        public User getCurrentUser()
        {
            return currentUser;
        }
        public void setCurrentUser(User user)
        {
            currentUser = user;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UrlImageManager urlManager = new UrlImageManager();
            setCurrentUser((User)Session["UserLoged"]);


            if (!IsPostBack)
            {
                UserManager userManager = new UserManager();
                userFullName.InnerText = currentUser.Name + " " + currentUser.HalfName;
                userSign.InnerText = currentUser.UserSign.Name;
                userElement.InnerText = currentUser.UserSign.Element;
                birthday.InnerText = currentUser.DateOfBirth.Date.ToString();
                userGender.InnerText = currentUser.Gender.ToString();
                divCurrentUserCard.Attributes["class"] = GetCardCssClass(currentUser.UserSign.Element);
                var users = userManager.GetAllUsers();
                rptUsers2.DataSource = users;
                rptUsers2.DataBind();

            }

        }
       
        protected string GetCardCssClass(string userSignElement)
        {
            switch (userSignElement)
            {
                case "Fire":
                    return "card text-white bg-danger mb-3";
                case "Water":
                    return "card text-white bg-info mb-3";
                case "Air":
                    return "card text-white bg-warning mb-3";
                default:
                    return "card text-white bg-success mb-3";
            }
        }
    }
}