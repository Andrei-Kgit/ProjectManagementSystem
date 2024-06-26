using ProjectManagementSystem.Scripts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class AdminsWindow : Window
    {
        private readonly string _pathToFile = $"{Environment.CurrentDirectory}\\tasks.json";
        private BindingList<TaskModel> _tasks;
        private ListSaveSystem<TaskModel> _saveSystem;

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
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }

        private void ExitClickButton(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
