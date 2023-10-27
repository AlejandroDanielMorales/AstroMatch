using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace Domain
{
    public class User
    {
        private int Id;

        private string Password;

        private string hashPass;

        private string saltPass;

        public string getPassword()
        {
            return Password;
        }
        public string gethashPass()
        {
            return hashPass;
        }
        public string getsaltPass()
        {
            return saltPass;
        }
        public int getIdUser()
        {
            return Id;
        }
        public void setIdUser(int id)
        {
            Id = id;
        }
        public void setPassword(string password)
        {
            Password = password;
        }

        public void sethashPass(string hash)
        {
            hashPass = hash;
        }

        public void setsaltPass(string salt)
        {
            saltPass = salt;

        }

        public string Name { get; set; }
        public string HalfName { get; set; }
        public string Email { get; set; }
        public char Gender { get; set; }
        public DateTime DateOfRegister { get; set; }
        public DateTime DateOfBirth { get; set; }  
        public Sign UserSign { get; set; }
        public string Sign { get; set; }

        public UrlImage ProfilePhoto { get; set; }
        public User()
        {
        }
        public User( string name, string halfname, string email, string password, DateTime dateOfRegister, DateTime dateOfBirth, char gender)
        {
          
            Name = name;
            HalfName = halfname;
            Email = email;
            DateOfRegister = dateOfRegister;
            DateOfBirth = dateOfBirth;
            UserSign = new Sign(dateOfBirth);
            setPassword(password);
            Gender = gender;
        }
        public void loadUserPropertysFromDb(int id, string name, string halfname, string email, string password, DateTime dateOfRegister, DateTime dateOfBirth, string hash,string salt)
        {
            Id = id;
            Name = name;
            HalfName = halfname;
            Email = email;
            DateOfRegister = dateOfRegister;
            DateOfBirth = dateOfBirth;
            UserSign = new Sign(dateOfBirth);
            setsaltPass(salt);
            sethashPass(hash);
        }
       

        public string GenerateRandomSalt(int longitud)
        {
            const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var randomBytes = new byte[longitud];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }

            var sal = new StringBuilder(longitud);

            foreach (var byteAleatorio in randomBytes)
            {
                sal.Append(caracteresPermitidos[byteAleatorio % caracteresPermitidos.Length]);
            }

            return sal.ToString();
        }
        public string CalculteHashPass()
        {
            // Concatena la sal y la contraseña.
            string contraseñaSalteada = Password + getsaltPass();;

            // Calcula el hash de la contraseña con la sal.
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(contraseñaSalteada);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
        public string CalculteHashPass(string pass)
        {
            // Concatena la sal y la contraseña.
            string contraseñaSalteada = pass + getsaltPass();

            // Calcula el hash de la contraseña con la sal.
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(contraseñaSalteada);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
        public void GenerateHashAndSalt()
        {
            setsaltPass(GenerateRandomSalt(10));
            sethashPass(CalculteHashPass());
        }
    }
}
