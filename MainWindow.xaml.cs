using ProjectManagementSystem.Scripts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectManagementSystem
{
    public partial class MainWindow : Window
    {
        private RegistredUsers _registredUsers = RegistredUsers.GetInstance();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToRegistration(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            Hide();
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordTextBox.Password.Trim();
            string userName;
            switch (_registredUsers.AuthUser(login, password, out userName))
            {
                case AccountType.None:
                    MessageBox.Show("Введен неправильный логин или пароль");
                    break;
                case AccountType.User:
                    TasksWindow tasksWindow = new TasksWindow(userName);
                    tasksWindow.Show();
                    Hide();
                    break;
                case AccountType.Admin:
                    AdminsWindow adminsWindow = new AdminsWindow();
                    adminsWindow.Show();
                    Hide();
                    break;
                default:
                    MessageBox.Show("Введен неправильный логин или пароль");
                    break;
            }
        }
    }
}
