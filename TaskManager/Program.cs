using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Interfaces;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager
{
    internal class Program
    {
        static public TaskService taskService=new TaskService();
        static void Main(string[] args)
        {
            int choice = 0;
            int Id,userId;
            do {
                Console.WriteLine("====================\r\n1 Add Task\r\n2 View Tasks\r\n3 Update Task\r\n4 Delete Task \r\n5 Mark Completed\r \n7 Exit\r\n====================");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Details: Name | ID | Title | ID");
                        string Name = Console.ReadLine();
                        Id = Convert.ToInt32(Console.ReadLine());
                        User newUser = new User(Id,Name);
                        TaskItem newTask=new TaskItem();
                        newTask.Title=Console.ReadLine();
                        newTask.Id= Convert.ToInt32(Console.ReadLine());
                        newTask.AssignedUser = newUser;
                        taskService.AddTask(newTask);

                        break;

                    case 2:
                            Console.WriteLine("Task Id \t Title \t Status \t User Name \t User Id");
                        foreach(var task in taskService.GetAllTasks())
                        {
                            Console.WriteLine($"{task.Id} \t {task.Title} \t {task.IsCompleted} \t {task.AssignedUser.Name} \t {task.AssignedUser.Id}");
                        }
                        
                        break;
                    case 3:
                        Console.WriteLine("Details : Id | Title");
                        Id = Convert.ToInt32(Console.ReadLine());
                        string title = Console.ReadLine();
                        taskService.UpdateTask(Id, title);
                        break;
                    case 4:
                        Console.WriteLine("Details : Id");
                        Id = Convert.ToInt32(Console.ReadLine());
                        taskService.DeleteTask(Id);
                        break;
                    case 5:
                        Console.WriteLine("Details : Id");
                        Id = Convert.ToInt32(Console.ReadLine());
                        taskService.MarkCompleted(Id);
                        break;

                }
            } while (choice!=7);
        }
    }
}
