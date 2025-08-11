using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Linq.Expressions;


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

            //get all tasks
            List<Task> tasks = GetTasks(connectionString);
        }

        //Create a new database and table
        static void CreateDatabase(string connectionString)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var createTableCommand = connection.CreateCommand();
                createTableCommand.CommandText =
                @"
                    CREATE TABLE IF NOT EXISTS TASKS(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Description TEXT NOT NULL,
                        isComplited DATETIME DEFAULT CURRENT_TIMESTAMP
                    );  
                ";
                createTableCommand.ExecuteNonQuery();

            }
        }

        //Add a new task in database
        static bool AddTask(string connectionString, string name, string description)
        {
            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    var insertCommand = connection.CreateCommand();
                    insertCommand.CommandText =
                        @"
                        INSERT INTO Tasks (Name, Description)
                        VALUES ($name, $description);   
                        ";
                    insertCommand.Parameters.AddWithValue("$name", name);
                    insertCommand.Parameters.AddWithValue("$description", description);

                    insertCommand.ExecuteNonQuery();
                }
                Console.WriteLine($"Успех! Данные {name} и {description} добавлены в базу данных");
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"ОШИБКА! Ошибка при добавлении данных: {ex.Message}");
                throw;
                //return false;
            }
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
            public string Name { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public DateTime isComplited { get; set; }
        }
    }
}
