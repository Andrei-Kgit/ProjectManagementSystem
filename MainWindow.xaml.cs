using ProjectManagementSystem.Scripts;
using System.Windows;

namespace ProjectManagementSystem
{
    public partial class MainWindow : Window
    {
        private RegistredUsers _registredUsers = RegistredUsers.GetInstance();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToRegistrationButtonClick(object sender, RoutedEventArgs e)
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
                    AdminsWindow adminsWindow = new AdminsWindow(userName);
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
