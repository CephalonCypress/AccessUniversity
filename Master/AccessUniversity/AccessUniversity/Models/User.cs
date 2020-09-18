using System;
using System.Collections.Generic;
using System.Text;

namespace AccessUniversity.Models
{
    public class User
    {
        public int studentID { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public User() { }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
            this.studentID = studentID;
        }

        public bool VerifyLogin()
        {
            try
            {
                if ((this.password.Equals("") && (this.studentID.Equals("") || (this.username.Equals("")))))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch(NullReferenceException e)
            {
                return false;
            }
            
        }
    }
}
