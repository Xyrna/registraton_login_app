using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace registraton_login_app
{
    class Account
    {
        private static List<Account> accounts = new List<Account>();
        private string username;
        private string password;

        public Account(string _n, string _p)
        { 
            username = _n;
            password = _p;
        }

        public static bool RegisterAccount(string username, string password)
        {
            foreach (Account acc in accounts)
            {
                if (acc.username == username) return false;
            }
            accounts.Add(new Account(username, password));
            return true;
        }

        public static bool Login(string username, string password)
        {
            foreach (Account acc in accounts)
            {
                if (acc.username == username)
                {
                    if (acc.password == password) return true;
                    return false;
                }
            }
            return false;
        }

        public static bool AccountExists(string username)
        {
            foreach (Account acc in accounts)
            {
                if (acc.username == username) return true;
            }
            return false;
        }

    }
}
