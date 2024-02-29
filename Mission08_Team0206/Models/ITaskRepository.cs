namespace Mission08_Team0206.Models
{
    public interface ITaskRepository
    {
        List<TaskModel> Tasks { get; }

        public void AddATask(TaskModel t);
        public void EditATask(TaskModel t);
        public void DeleteATask(TaskModel t);

        List<Category> Categories { get; }
    }
}
