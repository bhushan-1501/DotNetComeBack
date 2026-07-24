using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Interfaces;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class TaskService : ITaskService
    {
        List<TaskItem> tasks = new List<TaskItem>();
        public bool AddTask(TaskItem task)
        {
            if (task != null)
            {
                tasks.Add(task);
                return true;
            }
            return false;
        }

        public bool DeleteTask(int id)
        {
            TaskItem searchedTask = tasks.FirstOrDefault(t => t.Id == id);
            return tasks.Remove(searchedTask);
        }

        public List<TaskItem> GetAllTasks()
        {
            return tasks;
        }

        public bool MarkCompleted(int id)
        {
            TaskItem searchedTask = tasks.FirstOrDefault(t => t.Id == id);
            if (searchedTask != null)
            {
                searchedTask.IsCompleted = true;
                return true;
            }
            return false;
        }

        public bool UpdateTask(int id, string newTitle)
        {
            TaskItem searchedTask = tasks.FirstOrDefault(t => t.Id == id);
            if (searchedTask != null)
            {
                searchedTask.Title = newTitle;
                return true;
            }
            return false;
        }

        public TaskItem GetTaskById(int id)
        {
            TaskItem searchedTask = tasks.FirstOrDefault(t => t.Id == id);
            return searchedTask;
        }
    }
}
