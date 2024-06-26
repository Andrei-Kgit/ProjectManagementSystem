using ProjectManagementSystem.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectManagementSystem
{
    public partial class RegistrationWindow : Window
    {
        private readonly string _pathToFile = $"{Environment.CurrentDirectory}\\registedUsers.json";
        private RegistredUsers _registredUsers = RegistredUsers.GetInstance();
        private ListSaveSystem<User> _saveSystem;

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void RegistrationButtonClick(object sender, RoutedEventArgs e)
        {
            bool loginIsValid = false;
            bool passIsValid = false;
            string login = LoginTextBox.Text.Trim();
            string password = PasswordTextBox.Password.Trim();
            //TODO изменить проверки через регулярные
            if (login.Length < 6)
            {
                LoginTextBox.ToolTip = "Логин должен содержать больше 5 символов";
                LoginTextBox.BorderBrush = Brushes.Red;
                loginIsValid = false;
            }
            else
            {
                LoginTextBox.ClearValue(BorderBrushProperty);
                loginIsValid = true;
            }

            if (password.Length < 6)
            {
                PasswordTextBox.ToolTip = "Пароль должен содержать больше 5 символов";
                PasswordTextBox.BorderBrush = Brushes.Red;
                passIsValid = false;
            }
            else
            {
                PasswordTextBox.ClearValue(BorderBrushProperty);
                passIsValid = true;
            }

            if (loginIsValid && passIsValid)
            {
                if (_registredUsers.RegUser(login, password))
                {
                    MessageBox.Show("Успешно");
                    Hide();
                }
                else
                {
                    MessageBox.Show("Такой логин уже занят");
                }
            }
        }
    }
}
