using Microsoft.Data.SqlClient;
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
        string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=SalesDB;Integrated Security=True;TrustServerCertificate=True;";

        public bool AddTask(TaskItem task)
        {
            if (task != null)
            {
                try
                {
                    using (SqlConnection conn=new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "INSERT INTO Sales.Tasks (Title, IsCompleted, UserId) VALUES (@Title, @IsCompleted, @AssignedUserId)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Title", task.Title);
                            cmd.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);
                            cmd.Parameters.AddWithValue("@AssignedUserId", task.AssignedUser.Id);
                            cmd.ExecuteNonQuery();
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding task: " + ex.Message);
                }
                return false;
                    //Data.predefinedTasks.Add(task);
                    //return true;
                }
            throw new TaskNotFoundException("Task Not Found");
        }


        public bool DeleteTask(int id)
        {
            //TaskItem searchedTask = Data.predefinedTasks.FirstOrDefault(t => t.Id == id);
            //if (searchedTask != null)
            //    return Data.predefinedTasks.Remove(searchedTask);
            //else
            //    throw new TaskNotFoundException("Task Not Found");
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "Delete Sales.Tasks where Id=@id";
                    using(SqlCommand cmd=new SqlCommand(query, conn)){
                        cmd.Parameters.AddWithValue("@id", id);
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            throw new TaskNotFoundException("Task Not Found");
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting task: " + ex.Message);
            }
            return false;

        }

        public async Task<List<TaskItem>> GetAllTasks()
        {
            //await Task.Delay(1000);
            //return Data.predefinedTasks;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select t.Id,t.Title,t.UserId,t.IsCompleted ,u.Name from Sales.Tasks t Inner Join Sales.[User] u on t.UserId=u.Id";
                using (SqlCommand cmd=new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        List<TaskItem> tasks = new List<TaskItem>();

                        while (await reader.ReadAsync())
                        {
                            tasks.Add(new TaskItem
                            {
                                Id = (int)reader["Id"],
                                Title = reader["Title"].ToString(),
                                IsCompleted = (bool)reader["IsCompleted"],
                                AssignedUser=new User (
                                    (int)reader["UserId"],
                                     reader["Name"].ToString()
                                    )
                            });
                        }

                        return tasks;
                    }
                }
            }
        }

        public bool MarkCompleted(int id)
        {
            //TaskItem searchedTask = Data.predefinedTasks.FirstOrDefault(t => t.Id == id);
            //if (searchedTask != null)
            //{
            //    searchedTask.IsCompleted = true;
            //    return true;
            //}
            //throw new TaskNotFoundException("Task Not Found");

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "Update Sales.Tasks set IsCompleted=@isCompleted where Id=@id";
                using(SqlCommand cmd=new SqlCommand(query, conn)){
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@isCompleted", true);
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        throw new TaskNotFoundException("Task Not Found");
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        public bool UpdateTask(int id, string newTitle)
        {
            //TaskItem searchedTask = Data.predefinedTasks.FirstOrDefault(t => t.Id == id);
            //if (searchedTask != null)
            //{
            //    searchedTask.Title = newTitle;
            //    return true;
            //}   
            //throw new TaskNotFoundException("Task Not Found");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "Update Sales.Tasks Set Title=@newTitle where Id=@id"; 

                using(SqlCommand cmd=new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@newTitle", newTitle);
                    if(cmd.ExecuteNonQuery() == 0)
                    {
                        throw new TaskNotFoundException("Task Not Found");
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        public TaskItem GetTaskById(int id)
        {
            using( SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select t.Id,t.Title,t.UserId,t.IsCompleted ,u.Name from Sales.Tasks t Inner Join Sales.[User] u on t.UserId=u.Id where t.Id=@id";
                using (SqlCommand cmd=new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read())
                        {
                            return new TaskItem
                            {
                                Id = (int)reader["Id"],
                                Title = reader["Title"].ToString(),
                                IsCompleted = (bool)reader["IsCompleted"],
                                AssignedUser=new User (
                                    (int)reader["UserId"],
                                     reader["Name"].ToString()
                                    )
                            };
                        }
                        else
                        {
                            throw new TaskNotFoundException("Task Not Found");
                        }
                    }
                }
            }
        }

        public List<TaskItem> FilterdTasks(Predicate<TaskItem> predicate)
        {
            return Data.predefinedTasks.FindAll(predicate);
        }
    }
}
