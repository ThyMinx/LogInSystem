using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_NoGUI
{
    class User
    {
        private string mUsername;
        private string mPassword;

        public User(string pUsername, string pPassword)
        {
            mUsername = pUsername;
            mPassword = pPassword;

            Program.users.Add(mUsername,this);
        }

        public string GetPassword()
        {
            return mPassword;
        }

    }
}
