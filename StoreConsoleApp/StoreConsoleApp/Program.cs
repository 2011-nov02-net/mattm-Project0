using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Store.Library;
using System.Collections.Generic;
using DataAccessLibrary;
using DataAccessLibrary.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.IO;




namespace Store.ConsoleApp
{
    class Program
    {
        static DbContextOptions<project0dbContext> s_dbContextOptions;
        static void Main(string[] args)
        {
            Writer writer = new Writer();
            Menu menu = new Menu();

            using var logStream = new StreamWriter("ef-logs.txt");
            var optionsBuilder = new DbContextOptionsBuilder<project0dbContext>();
            optionsBuilder.UseSqlServer(getConnectionString());
            optionsBuilder.LogTo(logStream.Write, LogLevel.Debug);
            s_dbContextOptions = optionsBuilder.Options;
            using var dbContext = new project0dbContext(s_dbContextOptions);
            Repository repo = new Repository(dbContext);

            menu.displayMenu(repo);

            static string getConnectionString()
            {
                string path = "C:/Users/mgm21/Desktop/revature/mattm-Project0/connectionstring.json";
                string json;
                try
                {
                    json = File.ReadAllText(path);
      
                }
                catch (IOException)
                {
                    Console.WriteLine($"required file {path} not found. should just be the connection string in quotes.");
                    throw;
                }
                string connectionString = JsonSerializer.Deserialize<string>(json);
                return connectionString;
            }








        }
    }
}
