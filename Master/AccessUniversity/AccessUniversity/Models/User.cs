using System;
using System.Collections.Generic;
using System.Text;

namespace AccessUniversity.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public bool VerifyLogin()
        {
            try
            {
                if (this.Password.Equals("") && (this.Username.Equals("")))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (NullReferenceException)
            {
                return false;
            }
            
        }
    }
}
