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
        public List<TaskItem> tasks = new List<TaskItem>();
        public void AddTask(TaskItem task)
        {
            tasks.Add(task);
            Console.WriteLine(task.Title + "Added successfully.");
        }

        public void DeleteTask(int id)
        {
            TaskItem searchedTask=tasks.FirstOrDefault(t=>t.Id==id);
            tasks.Remove(searchedTask);
            Console.WriteLine(searchedTask.Title + "Deleted successfully.");
        }

        public List<TaskItem> GetAllTasks()
        {
            return tasks;
        }

        public void MarkCompleted(int id)
        {
            TaskItem searchedTask = tasks.FirstOrDefault(t => t.Id == id);
            searchedTask.IsCompleted = true;
            Console.WriteLine(searchedTask.Title + "Completed successfully.");
        }

        public void UpdateTask(int id, string newTitle)
        {
            TaskItem searchedTask = tasks.FirstOrDefault(t => t.Id == id);
            searchedTask.Title = newTitle;
            Console.WriteLine(searchedTask.Title + "Updated successfully.");
        }

        public TaskItem GetTaskById(int id) {
            TaskItem searchedTask = tasks.FirstOrDefault(t => t.Id == id);
            return searchedTask;
        }
    }
}
