using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models.SeededData
{
    public static class Data
    {
        public static List<User> users = new List<User>
{
    new User(1, "Bhushan"),
    new User(2, "Rahul"),
    new User(3, "Priya"),
    new User(4, "Amit"),
    new User(5, "Sneha")
};
        public static List<TaskItem> predefinedTasks = new List<TaskItem>
{
    new TaskItem
    {
        Id = 1,
        Title = "Create",
        AssignedUser = users[0],
        IsCompleted = false
    },

    new TaskItem
    {
        Id = 2,
        Title = "Implement",
        AssignedUser = users[1],
        IsCompleted = true
    },

    new TaskItem
    {
        Id = 3,
        Title = "Design",
        AssignedUser = users[2],
        IsCompleted = false
    },

    new TaskItem
    {
        Id = 4,
        Title = "Create",
        AssignedUser = users[3],
        IsCompleted = true
    },

    new TaskItem
    {
        Id = 5,
        Title = "Fixing",
        AssignedUser = users[0],
        IsCompleted = false
    },

    new TaskItem
    {
        Id = 6,
        Title = "Optimize",
        AssignedUser = users[4],
        IsCompleted = false
    },

    new TaskItem
    {
        Id = 7,
        Title = "Implement",
        AssignedUser = users[1],
        IsCompleted = true
    },

    new TaskItem
    {
        Id = 8,
        Title = "Writing",
        AssignedUser = users[2],
        IsCompleted = false
    },

    new TaskItem
    {
        Id = 9,
        Title = "Deploy",
        AssignedUser = users[3],
        IsCompleted = false
    },

    new TaskItem
    {
        Id = 10,
        Title = "Prepare",
        AssignedUser = users[4],
        IsCompleted = true
    }
};
    }
}
