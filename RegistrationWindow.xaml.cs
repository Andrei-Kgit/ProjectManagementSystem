using ProjectManagementSystem.Scripts;
using System;
using System.Windows;
using System.Windows.Media;
using System.Text.RegularExpressions;

namespace ProjectManagementSystem
{
    public partial class RegistrationWindow : Window
    {
        public event Action OnRegisterComplete;
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

            Regex validateLogin = new Regex(@"^(?=.*?[a-z]).{5,}$");
            Regex validatePassword = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{5,}$");

            if (!validateLogin.IsMatch(login))
            {
                LoginTextBox.ToolTip = "Логин должен содержать минимум 5 символов, включая буквы a-z";
                LoginTextBox.BorderBrush = Brushes.Red;
                loginIsValid = false;
            }
            else
            {
                LoginTextBox.ClearValue(BorderBrushProperty);
                loginIsValid = true;
            }

            if (!validatePassword.IsMatch(password))
            {
                PasswordTextBox.ToolTip = "Пароль должен содержать минимум 5 символов, включая символы a-z, A-Z, 0-9, #?!@$%^&*-";
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
                    OnRegisterComplete?.Invoke();
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
