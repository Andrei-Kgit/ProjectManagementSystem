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
            RegAdmin();

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

        public AccountType AuthUser(string login, string password, out string userName)
        {
            userName = string.Empty;
            RegAdmin();
            if (!CheckUserRegistred(login))
                return AccountType.None;

            foreach(var user in _users)
            {
                if(user.Login == login)
                    if(user.Password == password)
                    {
                        userName = user.Login;
                        return user.AccountType;
                    }
            }
            return AccountType.None;
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

        private void RegAdmin()
        {
            if (!CheckUserRegistred(ADMINSNAME))
                _users.Add(new User(ADMINSNAME, ADMINSNAME, AccountType.Admin));
        }
    }
}
