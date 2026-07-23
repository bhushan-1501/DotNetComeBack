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
        void AddTask(TaskItem task);
        List<TaskItem> GetAllTasks();
        void DeleteTask(int id);
        void MarkCompleted(int id);
        void UpdateTask(int id, string newTitle);

    }
}
