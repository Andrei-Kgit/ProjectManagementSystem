using ProjectManagementSystem.Scripts;
using System;
using System.ComponentModel;
using System.Windows;

namespace ProjectManagementSystem
{
    public partial class AdminsWindow : Window
    {
        private readonly string _pathToFile = $"{Environment.CurrentDirectory}\\tasks.json";
        private BindingList<TaskModel> _tasks;
        private ListSaveSystem<TaskModel> _saveSystem;
        private RegistrationWindow _registrationWindow = new RegistrationWindow();
        private RegistredUsers _registredUsers = RegistredUsers.GetInstance();

        public AdminsWindow(string login)
        {
            InitializeComponent();
            UserNameTextBox.Text = login;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _saveSystem = new ListSaveSystem<TaskModel>(_pathToFile);

            try
            {
                _tasks = _saveSystem.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            TaskGrid.ItemsSource = _tasks;
            _tasks.ListChanged += TasksListChanged;
            RefreshDataGridItems();
            _registrationWindow.OnRegisterComplete += RefreshDataGridItems;
        }

        private void RefreshDataGridItems()
        {
            EmployeeComboBox.ItemsSource = _registredUsers.UserNames;
            EmployeeToDelete.ItemsSource = _registredUsers.UserNames;
            EmployeeToDelete.Text = "Выберите логин";
        }

        private void TasksListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                _saveSystem.SaveData(sender);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            //если нужны специфические ивенты
            //switch (e.ListChangedType)
            //{
            //    case ListChangedType.ItemAdded:
            //    case ListChangedType.ItemDeleted:
            //    case ListChangedType.ItemChanged:
            //        break;
            //    default:
            //        break;
            //}
        }

        private void AddRowButtonClick(object sender, RoutedEventArgs e)
        {
            _tasks.Add(new TaskModel());
        }

        private void RegEmployeeButtonClick(object sender, RoutedEventArgs e)
        {

            _registrationWindow.Show();
        }

        private void ExitClickButton(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            _registrationWindow.OnRegisterComplete -= RefreshDataGridItems;
        }

        private void DeleteEmployee(object sender, RoutedEventArgs e)
        {
            if (EmployeeToDelete.SelectedValue != null)
            {
                string login = EmployeeToDelete.SelectedValue as string;
                if (_registredUsers.DelUser(login))
                {
                    MessageBox.Show("Аккаунт удален!");
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении!");
                }
                RefreshDataGridItems();
            }
            else
            {
                MessageBox.Show("Работник не выбран!");
            }
        }
    }
}
