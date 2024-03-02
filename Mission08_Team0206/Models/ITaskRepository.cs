namespace Mission08_Team0206.Models
{
    public interface ITaskRepository
    {
        List<TaskModel> Tasks { get; }

        // Have to have the right way to link the actions
        public void AddATask(TaskModel t);
        public void EditATask(TaskModel t);
        public void DeleteATask(TaskModel t);

        List<Category> Categories { get; }
    }
}
