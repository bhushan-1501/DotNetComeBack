using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.CustomExceptions;
using TaskManager.Interfaces;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager
{
    internal class Program
    {
        static public ITaskService taskService = new TaskService();

        static void showTasks(List<TaskItem> t)
        {
            Console.WriteLine("Task Id \t\t\t Title \t\t\t Status \t\t\t User Name \t\t\t User Id");
            foreach (var task in t)
            {
                Console.WriteLine($"{task.Id} \t\t\t {task.Title} \t\t\t {task.IsCompleted} \t\t\t {task.AssignedUser.Name} \t\t\t {task.AssignedUser.Id}");
            }
        }
        static async Task Main(string[] args)
        {

            int choice = 0;
            int Id, userId;
            do
            {
                Console.WriteLine("====================\nMain Menu\r\n\t1. Add Task\r\n\t2. View Tasks\r\n\t3. Update Task\r\n\t4. Delete Task \r\n\t5. Mark Completed\r\n\t6. Filter Tasks\r \n\t7. Exit\r\n====================");
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

                        try
                        {
                            if (taskService.AddTask(newTask))
                                Console.WriteLine(newTask.Title + " Added successfully.");
                        }
                        catch (TaskNotFoundException e) { Console.WriteLine(e.Message); }
                        catch (Exception ex) { Console.WriteLine(ex.ToString()); }


                        break;

                    case 2:
                        List<TaskItem> retrivedList =await taskService.GetAllTasks();
                        if (retrivedList.Count > 0)
                        {
                            showTasks(retrivedList);
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
                        try
                        {
                            if (taskService.UpdateTask(Id, title))
                            {
                                Console.WriteLine("Task Updated successfully.");
                            }
                        }
                        catch (TaskNotFoundException e) { Console.WriteLine(e.Message); }
                        catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                        break;
                    case 4:

                        Console.WriteLine("Details : Id");
                        Id = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            if (taskService.DeleteTask(Id))
                            {
                                Console.WriteLine("Task Deleted Successfully");
                            }
                        }
                        catch (TaskNotFoundException e) { Console.WriteLine(e.Message); }
                        catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                        break;
                    case 5:
                        Console.WriteLine("Details : Id");
                        Id = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            if (taskService.MarkCompleted(Id))
                            {

                                Console.WriteLine("Task Completed successfully.");
                            }
                        }
                        catch (TaskNotFoundException e) { Console.WriteLine(e.Message); }
                        catch (Exception ex) { Console.WriteLine(ex.ToString()); }

                        break;

                    case 6:
                        Console.WriteLine("Filter Choice : \n\t1.Completed \n\t2. Pending");
                        int subChoice = Convert.ToInt32(Console.ReadLine());
                        switch (subChoice)
                        {
                            case 1:
                                showTasks(taskService.FilterdTasks(t => t.IsCompleted));
                                break;
                            case 2:
                                showTasks(taskService.FilterdTasks(t => !t.IsCompleted));
                                break;
                        }
                        break;
                    case 7:
                        Console.WriteLine("Thank You!!!!!");
                        break;
                    default: Console.WriteLine("Please Enter Valid Choice"); break;
                }
            } while (choice != 7);
        }
    }
}
