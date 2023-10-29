using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using Domain;

namespace Management
{
    public class UserManager
    {

        public UserManager()
        {
           
        }

        public User GetUserById(int id)
        {
            DataManager dataManager = new DataManager();
            UrlImageManager urlImageManager = new UrlImageManager();
            dataManager.setQuery("SELECT * FROM Usuarios WHERE Id = @Id");
            dataManager.setParameter("@Id", id);
            dataManager.executeRead();

            if (dataManager.Lector.HasRows)
            {
                dataManager.Lector.Read();
                User user = new User();
                UrlImage urlImage = urlImageManager.UserProfilePhoto(id);
                user.setIdUser((int)dataManager.Lector["Id"]);
                user.Name = (string)dataManager.Lector["Nombre"];
                user.HalfName = (string)dataManager.Lector["Apellido"];
                user.DateOfBirth = (DateTime)dataManager.Lector["FechaNacimiento"];
                user.DateOfRegister = (DateTime)dataManager.Lector["FechaRegistro"];
                user.Email = (string)dataManager.Lector["CorreoElectronico"];
                user.sethashPass((string)dataManager.Lector["HashContraseña"]);
                user.setsaltPass((string)dataManager.Lector["Sal"]);
                string g = (string)dataManager.Lector["Sexo"];
                user.Gender = g[0];
                DateTime birth = (DateTime)dataManager.Lector["FechaNacimiento"];
                user.UserSign = new Sign(birth);
                if (urlImage == null)
                {
                    UrlImage aux = new UrlImage();
                    aux.Url = "https://tinyurl.com/mr2scwy8";
                    user.ProfilePhoto = aux;
                }
                else
                {
                    user.ProfilePhoto = urlImage;
              
                }

                dataManager.closeConection();
                return user;
            }

            dataManager.closeConection();
            return null;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            UrlImageManager urlImageManager = new UrlImageManager();
            DataManager dataManager = new DataManager();

            dataManager.ClearCommand();
            dataManager.setQuery("SELECT * FROM Usuarios");
            dataManager.executeRead();

            while (dataManager.Lector.Read())
            {
                UrlImage urlImage = new UrlImage();
                urlImage = urlImageManager.UserProfilePhoto((int)dataManager.Lector["Id"]);
                User user = new User();
                user.setIdUser((int)dataManager.Lector["Id"]);
                user.Name = (string)dataManager.Lector["Nombre"];
                user.HalfName = (string)dataManager.Lector["Apellido"];
                user.DateOfBirth = (DateTime)dataManager.Lector["FechaNacimiento"];
                user.DateOfRegister = (DateTime)dataManager.Lector["FechaRegistro"];
                user.Email = (string)dataManager.Lector["CorreoElectronico"];
                user.sethashPass((string)dataManager.Lector["HashContraseña"]);
                user.setsaltPass((string)dataManager.Lector["Sal"]);
                user.Sign = (string)dataManager.Lector["Signo"];
                string g = (string)dataManager.Lector["Sexo"];
                user.Gender = g[0];
                DateTime birth = (DateTime)dataManager.Lector["FechaNacimiento"];
                user.UserSign = new Sign(birth);
                if (urlImage == null)
                {
                    UrlImage aux = new UrlImage();
                    aux.Url = "https://tinyurl.com/mr2scwy8";
                    user.ProfilePhoto = aux;
                }
                else
                {
                    user.ProfilePhoto = urlImage;
                  
                }

                users.Add(user);
            }

            dataManager.closeConection();
            return users;
        }
        public string rootImage(string file)
        {
            string root;

            root = "/Uploads/" + file;

            return root;
        }
        public bool VerificarContraseña(string contraseñaProporcionada,User user)
        {
            string hashContraseñaProporcionada = user.CalculteHashPass(contraseñaProporcionada); 
            return hashContraseñaProporcionada == user.gethashPass();
        }
        public void AgregarUsuario(User user)
        {
            DataManager dataManager = new DataManager();
            // Genera una nueva sal para el usuario.
            user.GenerateHashAndSalt();

            // Calcula el hash de la contraseña con la nueva sal.
            string hashContraseña = user.CalculteHashPass();
            dataManager.ClearCommand();
            dataManager.setQuery("INSERT INTO Usuarios (Nombre, Apellido, FechaNacimiento, CorreoElectronico, Sexo, HashContraseña, Sal, FechaRegistro,Signo) VALUES (@Nombre, @Apellido, @FechaNacimiento, @CorreoElectronico, @Sexo, @HashContraseña, @Sal, @FechaRegistro,@Signo)");
            dataManager.setParameter("@Nombre", user.Name);
            dataManager.setParameter("@Apellido", user.HalfName);
            dataManager.setParameter("@FechaNacimiento", user.DateOfBirth);
            dataManager.setParameter("@CorreoElectronico", user.Email);
            dataManager.setParameter("@Sexo", user.Gender);
            dataManager.setParameter("@HashContraseña", hashContraseña);
            dataManager.setParameter("@Sal", user.getsaltPass());
            dataManager.setParameter("@FechaRegistro", user.DateOfRegister);
            Sign sign = new Sign(user.DateOfBirth);
            string Signo = sign.Name;
            dataManager.setParameter("@Signo", Signo);
            dataManager.executeRead();
            dataManager.closeConection();

        }
        public User GetUserByEmail(string email)
        {
            DataManager dataManager = new DataManager();
            UrlImageManager urlImageManager = new UrlImageManager();
            dataManager.ClearCommand();
            string consulta = "SELECT * FROM Usuarios WHERE CorreoElectronico = @Email";
            dataManager.setQuery(consulta);
            dataManager.setParameter("Email", email);
            dataManager.executeRead();

            if (dataManager.Lector.HasRows)
            {
                dataManager.Lector.Read();
                User user = new User();
                UrlImage urlImage = urlImageManager.UserProfilePhoto((int)dataManager.Lector["Id"]);
                user.setIdUser((int)dataManager.Lector["Id"]);
                user.Name = (string)dataManager.Lector["Nombre"];
                user.HalfName = (string)dataManager.Lector["Apellido"];
                user.DateOfBirth = (DateTime)dataManager.Lector["FechaNacimiento"];
                user.DateOfRegister = (DateTime)dataManager.Lector["FechaRegistro"];
                user.Email = (string)dataManager.Lector["CorreoElectronico"];
                user.sethashPass((string)dataManager.Lector["HashContraseña"]);
                user.setsaltPass((string)dataManager.Lector["Sal"]);
                string g = (string)dataManager.Lector["Sexo"];
                user.Gender = g[0];
                DateTime birth = (DateTime)dataManager.Lector["FechaNacimiento"];
                user.UserSign = new Sign(birth);
                if (urlImage == null)
                {
                    UrlImage aux = new UrlImage();
                    aux.Url = "https://tinyurl.com/mr2scwy8";
                    user.ProfilePhoto = aux;
                }
                else
                {
                    user.ProfilePhoto = urlImage;
                    
                }

                dataManager.closeConection();
                return user;
            }

            dataManager.closeConection();
            return null;
        }
        public bool VerificarCredenciales(string email, string password)
        {
            User user = GetUserByEmail(email);
            if (user != null)
            {
                string hashContraseñaProporcionada = user.CalculteHashPass(password);
                return hashContraseñaProporcionada == user.gethashPass();
            }
            return false;
        }
    }
}