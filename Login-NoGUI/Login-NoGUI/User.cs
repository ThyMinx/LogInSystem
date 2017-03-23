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
        private int mBirthYear;

        public User(string pUsername, string pPassword, int pBirthYear)
        {
            mUsername = pUsername;
            mPassword = pPassword;
            mBirthYear = pBirthYear;

            Program.users.Add(mUsername,this);
        }

        public string GetPassword()
        {
            return mPassword;
        }

    }
}
