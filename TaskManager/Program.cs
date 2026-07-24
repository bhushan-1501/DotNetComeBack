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
        static public ITaskService taskService = new TaskService();
        static void Main(string[] args)
        {
            int choice = 0;
            int Id, userId;
            do
            {
                Console.WriteLine("====================\r\n1 Add Task\r\n2 View Tasks\r\n3 Update Task\r\n4 Delete Task \r\n5 Mark Completed\r \n7 Exit\r\n====================");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Details: Name | ID | Title | ID");
                        string Name = Console.ReadLine();
                        Id = Convert.ToInt32(Console.ReadLine());
                        User newUser = new User(Id, Name);
                        TaskItem newTask = new TaskItem();
                        newTask.Title = Console.ReadLine();
                        newTask.Id = Convert.ToInt32(Console.ReadLine());
                        newTask.AssignedUser = newUser;
                        if (taskService.AddTask(newTask))
                        {
                            Console.WriteLine(newTask.Title + " Added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Some Error occured");
                        }


                        break;

                    case 2:
                        List<TaskItem> retrivedList = taskService.GetAllTasks();
                        if(retrivedList.Count > 0)
                        {
                        Console.WriteLine("Task Id \t Title \t Status \t User Name \t User Id");
                        foreach (var task in retrivedList)
                        {
                            Console.WriteLine($"{task.Id} \t {task.Title} \t {task.IsCompleted} \t {task.AssignedUser.Name} \t {task.AssignedUser.Id}");
                        }

                        }
                        else
                        {
                            Console.WriteLine("No Data...");
                        }

                        break;
                    case 3:
                        Console.WriteLine("Details : Id | Title");
                        Id = Convert.ToInt32(Console.ReadLine());
                        string title = Console.ReadLine();
                        if(taskService.UpdateTask(Id, title))
                        {
                            Console.WriteLine("Task Updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Some Error Occured");
                        }
                        break;
                    case 4:

                        Console.WriteLine("Details : Id");
                        Id = Convert.ToInt32(Console.ReadLine());
                        if (taskService.DeleteTask(Id))
                        {
                            Console.WriteLine("Task Deleted Successfully");
                        }
                        else
                        {
                            Console.WriteLine("Some Error Occured");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Details : Id");
                        Id = Convert.ToInt32(Console.ReadLine());
                        if (taskService.MarkCompleted(Id))
                        {

                            Console.WriteLine("Task Completed successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Some Error Occured");
                        }
                        break;

                }
            } while (choice != 7);
        }
    }
}
