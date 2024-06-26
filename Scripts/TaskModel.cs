namespace ProjectManagementSystem.Scripts
{
    internal class TaskModel
    {
        public string ProjectID { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string Employee { get; set; }
        public TaskState State { get; set; } = TaskState.ToDo;

        public TaskModel(string projectID, string name, string discription, string employee)
        {
            ProjectID = projectID;
            Name = name;
            Discription = discription;
            Employee = employee;
        }
    }

    public enum TaskState
    { 
        ToDo, InProgress, Done
    }
}
