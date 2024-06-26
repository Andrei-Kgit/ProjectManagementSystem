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
        private BindingList<TaskModel> _tasks;

        public AdminsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _tasks = new BindingList<TaskModel>()
            {
                new TaskModel("P1", "task 1","need to do task1","Bob"),
                new TaskModel("P1", "task 2","need to do task2","Tom"),
                new TaskModel("P2", "task 1","need to do task1","Dom"),
            };
            TaskGrid.ItemsSource = _tasks;
        }
    }
}
