using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Scripts
{
    internal class RegistredUsers : Singleton<RegistredUsers>
    {
        private List<User> _users = new List<User>();
        private string ADMINSNAME = "Admin";

        public bool RegUser(string login, string password, AccountType accountType = AccountType.User)
        {
            if (!CheckUserRegistred(ADMINSNAME))
                _users.Add(new User(ADMINSNAME, ADMINSNAME, AccountType.Admin));

            if (!CheckUserRegistred(login))
            {
                _users.Add(new User(login, password, accountType));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AuthUser(string login, string password)
        {
            if(!CheckUserRegistred(login))
                return false;

            foreach(var user in _users)
            {
                if(user.Login == login)
                    if(user.Password == password)
                        return true;
            }
            return false;
        }

        private bool CheckUserRegistred(string login)
        {
            foreach (var user in _users)
            {
                if (user.Login == login)
                    return true;
            }
            return false;
        }
    }
}
