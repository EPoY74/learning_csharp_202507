using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;


namespace TodoApp

{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize SQLitePCL to use SQLite
            SQLitePCL.Batteries.Init();
            // Путь к базе данных (если файла нет, он будет создан)
            string connectionString = "Data Source=task.db";

            //Create a new database and table if it doesn't exist
            CreateDatabase(connectionString);

            //Add a new task in database

            bool isTaskAdded = AddTask(connectionString, "task 3", "Description Task 3");
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

            DisplayTasks(tasks);
        }

        //Create a new database and table
        static void CreateDatabase(string connectionString)
        {
            try
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
                            isComplited BOOLEAN DEFAULT 0,
                        );  
                    ";
                    createTableCommand.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ОШИБКА! Ошибка при создании базы данных: {ex.Message}");
                throw;
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

                    var numOfRecords = insertCommand.ExecuteNonQuery();
                    if (numOfRecords > 0)
                    { 
                        Console.WriteLine($"Успех! Данные \"{name}\" и \"{description}\" добавлены в базу данных");
                        Console.WriteLine($"Добавлено: {numOfRecords} строк(а).");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Не удалось добавить данные в базу данных.");
                        return false;
                    }
                }
                
                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"ОШИБКА! Ошибка при добавлении данных: {ex.Message}");
                throw;
            }
        }
        

        // get all tasks from database
        static List<Task> GetTasks(string connectionString)
        {
            try
            {
                List<Task> tasks = new List<Task>();

                using(var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    var selectCommand = connection.CreateCommand();
                    selectCommand.CommandText = "SELECT * FROM Tasks";

                    using (var reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        { 
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string description = reader.GetString(2);
                            bool isComplited = reader.GetBoolean(3);

                            tasks.Add(new Task
                            {
                                Id = id,
                                Name = name,
                                Description = description,
                                IsComplited = isComplited,
                            }
                            );
                        }
                    }
                }

                return tasks;
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                throw;
            }
        }

        static void DisplayTasks(List<Task> tasks)
        {
            if (tasks is not null && tasks.Count > 0)
            {
                foreach (var task in tasks)
                {
                    string outputtingTask = @$"
                    ID: {task.Id}, 
                    Name: {task.Name}, 
                    Description: {task.Description}, 
                    IsComplited: {task.IsComplited}";
                    Console.WriteLine(outputtingTask);
                }
            }
        }

        // Task class to represent a task in the todo app
        public class  Task
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public bool IsComplited { get; set; }
        }
    }
}
