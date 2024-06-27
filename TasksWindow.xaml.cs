using ProjectManagementSystem.Scripts;
using System;
using System.ComponentModel;
using System.Windows;
using System.Linq;

namespace ProjectManagementSystem
{
    public partial class TasksWindow : Window
    {
        private string UserName;
        private readonly string _pathToFile = $"{Environment.CurrentDirectory}\\tasks.json";
        private ListSaveSystem<TaskModel> _saveSystem;
        private BindingList<TaskModel> _tasks;
        private BindingList<TaskModel> _currUsersTasks;

        public TasksWindow(string login)
        {
            InitializeComponent();
            UserName = login;
            UserNameTextBox.Text = UserName;
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

            _currUsersTasks = SelectTasksByUser(UserName, _tasks);

            TaskGrid.ItemsSource = _currUsersTasks;
            _currUsersTasks.ListChanged += TasksListChanged;
        }

        private BindingList<TaskModel> SelectTasksByUser(string userName, BindingList<TaskModel> tasks)
        {
            if (tasks == null)
                return new BindingList<TaskModel>(tasks);

            BindingList<TaskModel> selectedTasks = new BindingList<TaskModel>(tasks.Where(x => x.Employee == UserName).ToList());
            return selectedTasks;
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

        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            _currUsersTasks.ListChanged -= TasksListChanged;
        }
    }
}
