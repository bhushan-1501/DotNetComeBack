using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Interfaces
{
    internal interface ITaskService
    {
        bool AddTask(TaskItem task);
        Task<List<TaskItem>> GetAllTasks();
        bool DeleteTask(int id);
        bool MarkCompleted(int id);
        bool UpdateTask(int id, string newTitle);
        TaskItem GetTaskById(int id);
        List<TaskItem> FilterdTasks(Predicate<TaskItem> predicate);
        

    }
}
