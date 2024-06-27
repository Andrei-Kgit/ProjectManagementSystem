using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace ProjectManagementSystem.Scripts
{
    internal class RegistredUsers : Singleton<RegistredUsers>
    {
        private string ADMINSNAME = "admin";
        private readonly string _pathToFile = $"{Environment.CurrentDirectory}\\registedUsers.json";
        private ListSaveSystem<User> _saveSystem;
        private BindingList<User> _users = new BindingList<User>();
        public List<string> UserNames { get; set; } = new List<string>();

        public RegistredUsers()
        {
            _saveSystem = new ListSaveSystem<User>(_pathToFile);
            try
            {
                _users = _saveSystem.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            FillUserNames();
        }

        private void FillUserNames()
        {
            if (_users != null)
            {
                UserNames = new List<string>();
                foreach (var user in _users)
                {
                    if (user.Login != ADMINSNAME)
                        UserNames.Add(user.Login);
                }
                UserNames.Sort();
            }
        }

        public bool RegUser(string login, string password, AccountType accountType = AccountType.User)
        {
            if (!CheckUserRegistred(ADMINSNAME))
                RegAdmin();

            if (!CheckUserRegistred(login))
            {
                _users.Add(new User(login, password, accountType));

                try
                {
                    _saveSystem.SaveData(_users);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                FillUserNames();
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

            foreach (var user in _users)
            {
                if (user.Login == login)
                    if (user.Password == password)
                    {
                        userName = user.Login;
                        return user.AccountType;
                    }
            }
            return AccountType.None;
        }

        public bool DelUser(string login)
        {
            if (login == ADMINSNAME)
                return false;

            if (CheckUserRegistred(login))
            {
                foreach (var user in _users)
                {
                    if (user.Login == login)
                    {
                        _users.Remove(user);
                        break;
                    }
                }

                try
                {
                    _saveSystem.SaveData(_users);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                FillUserNames();
                return true;
            }
            else
            {
                return false;
            }
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
