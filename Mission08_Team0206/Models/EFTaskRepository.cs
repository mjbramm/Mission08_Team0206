﻿using System.ComponentModel;

namespace Mission08_Team0206.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private TaskDbContext _context;
        public EFTaskRepository(TaskDbContext temp)
        {
            _context = temp;
        }

        //Models to pull in
        public List<TaskModel> Tasks => _context.Tasks.ToList();

        public List<Category> Categories => _context.Categories.ToList();

        //Adding, editing, and deleting actions to pull in
        public void AddATask(TaskModel t)
        {
            _context.Add(t);
            _context.SaveChanges();
        }

        public void EditATask(TaskModel t)
        {
            _context.Update(t);
            _context.SaveChanges();
        }

        public void DeleteATask(TaskModel t)
        {
            _context.Remove(t);
            _context.SaveChanges();
        }
    }
}
