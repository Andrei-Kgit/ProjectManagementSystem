using System.ComponentModel;

namespace ProjectManagementSystem.Scripts
{
    internal class TaskModel : INotifyPropertyChanged
    {
        private string _projectID;
        private string _name;
        private string _discription;
        private string _employee;
        private TaskState _state;
        public string ProjectID
        {
            get { return _projectID; }
            set
            {
                if (_projectID != value)
                    _projectID = value;
                OnPropertyChanged("ProjectID");
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                    _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Discription
        {
            get { return _discription; }
            set
            {
                if (_discription != value)
                    _discription = value;
                OnPropertyChanged("Discription");
            }
        }
        public string Employee
        {
            get { return _employee; }
            set
            {
                if (_employee != value)
                    _employee = value;
                OnPropertyChanged("Employee");
            }
        }
        public TaskState State
        {
            get { return _state; }
            set
            {
                if (_state != value)
                    _state = value;
                OnPropertyChanged("State");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public TaskModel(string projectID, string name, string discription, string employee)
        //{
        //    ProjectID = projectID;
        //    Name = name;
        //    Discription = discription;
        //    Employee = employee;
        //}
    }
}
