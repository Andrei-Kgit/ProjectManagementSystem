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

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordTextBox.Password.Trim();

            if(_registredUsers.AuthUser(login, password))
            {

            }
            else
            {
                MessageBox.Show("Введен неправильный логин или пароль");
            }
        }

        private void ShowTasksWindow(object sender, RoutedEventArgs e)
        {

        }

        private void ToRegistration(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("reg");
        }
    }
}
