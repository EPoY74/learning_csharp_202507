using Microsoft.Data.Sqlite;
using System;


namespace TodoApp

{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Путь к базе данных (если файла нет, он будет создан)
            string connectionString = "Data Source=task.db";

            //Create a new database and table if it doesn't exist
            CreateDatabase(connectionString);

            //Add a new task in database
            bool isTaskAdded = AddTask(connectionString, "task 1", "Description Task 1");
            if(isTaskAdded)
            {
                Console.WriteLine("Task added successfully");
            }
            else
            {
                Console.WriteLine("Failed to add task");
            }

            //Display all tasks
            List<Task> tasks = GetTasks(connectionString);
        }

        //Create a new database and table
        static void CreateDatabase(string connectionString)
        {
            
        }

        //Add a new task in database
        static bool AddTask(string connectionString, string name, string description)
        {
            return true; // Simulate adding a task
        }

        // get all tasks from database
        static List<Task> GetTasks(string connectionString)
        {
            return new List<Task>(); // Simulate getting tasks
        }

        // Task class to represent a task in the todo app
        public class  Task
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public DateTime isComplited { get; set; }
        }
    }
}
