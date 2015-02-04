using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace DAO
{
    class Login
    {
       //Variables for login

        private String userName;
        private String password;

        public String UserName
        {
            get { return userName; }
            set { userName = value; }
        }
       

        public String Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
