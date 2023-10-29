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

    public partial class Register : Page
    {
        protected void RegisterUser(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string halfName = txtHalfName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            DateTime dateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
            DateTime dateOfRegister = DateTime.Now;
            string g = txtGender.Text;
            char gender = g[0]; 
            User newUser = new User(name, halfName, email, password, dateOfRegister, dateOfBirth, gender);
            UserManager userManager = new UserManager();
            userManager.AgregarUsuario(newUser);
            string extension = Path.GetExtension(fileUploadProfilePicture.FileName);
            string fileName = Guid.NewGuid().ToString() + extension;
            string rutaCarpetaRaiz = Server.MapPath("~");
            string uploadFolder = rutaCarpetaRaiz;
            string filePath = Path.Combine(uploadFolder, fileName);
            fileUploadProfilePicture.SaveAs(filePath);
            UrlImageManager urlImageManager = new UrlImageManager();
            UrlImage urlImage = new UrlImage();
            User aux = userManager.GetUserByEmail(email);
            urlImage.IdUser = aux.getIdUser();
            urlImage.Url = fileName;
            urlImageManager.AddUserProfilePhoto(urlImage);
            Response.Redirect("Login.aspx");
        }
    }
}
