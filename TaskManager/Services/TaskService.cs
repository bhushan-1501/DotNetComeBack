using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.CustomExceptions;
using TaskManager.Interfaces;
using TaskManager.Models;
using TaskManager.Models.SeededData;

namespace TaskManager.Services
{
    public class TaskService : ITaskService
    {

        public bool AddTask(TaskItem task)
        {
            if (task != null)
            {
                Data.predefinedTasks.Add(task);
                return true;
            }
            throw new TaskNotFoundException("Task Not Found");
        }


        public bool DeleteTask(int id)
        {
            TaskItem searchedTask = Data.predefinedTasks.FirstOrDefault(t => t.Id == id);
            if (searchedTask != null)
                return Data.predefinedTasks.Remove(searchedTask);
            else
                throw new TaskNotFoundException("Task Not Found");
        }

        public async Task<List<TaskItem>> GetAllTasks()
        {
            await Task.Delay(1000);
            return Data.predefinedTasks;
        }

        public bool MarkCompleted(int id)
        {
            TaskItem searchedTask = Data.predefinedTasks.FirstOrDefault(t => t.Id == id);
            if (searchedTask != null)
            {
                searchedTask.IsCompleted = true;
                return true;
            }
            throw new TaskNotFoundException("Task Not Found");
        }

        public bool UpdateTask(int id, string newTitle)
        {
            TaskItem searchedTask = Data.predefinedTasks.FirstOrDefault(t => t.Id == id);
            if (searchedTask != null)
            {
                searchedTask.Title = newTitle;
                return true;
            }
            throw new TaskNotFoundException("Task Not Found");
        }

        public TaskItem GetTaskById(int id)
        {
            TaskItem searchedTask = Data.predefinedTasks.FirstOrDefault(t => t.Id == id);
            if (searchedTask != null)
                return searchedTask;
            else
                throw new TaskNotFoundException("Task Not Found");
        }

        public List<TaskItem> FilterdTasks(Predicate<TaskItem> predicate)
        {
            return Data.predefinedTasks.FindAll(predicate);
        }
    }
}
