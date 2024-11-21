using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Data.SqlClient;


namespace CryptoApp
{   

    public partial class App : Application
    {
       
        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            m_window.Activate();
        }

        private Window m_window;
           
    }
}

{      
    public class CreateDatabase
    {
        public static void Main(string[] args)

        string connectionString = "Server= -  ;Database=master;UserId= -  ;Password= -  ;"; 

        string databaseName = "cryptoappdb";

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
        {
        connection.Open();

        string checkDbSql = $"IF EXISTS (SELECT name FROM sys.databases WHERE name = '{databaseName}') DROP DATABASE {databaseName};";
        using (SqlCommand command = new SqlCommand(checkDbSql, connection))
        {
            command.ExecuteNonQuery();
        }

        string createDbSql = $"CREATE DATABASE {databaseName};";
        using (SqlCommand command = new SqlCommand(createDbSql, connection))
        {
            command.ExecuteNonQuery();
        }
        Console.WriteLine($"База данных '{databaseName}' создана успешно.");

        connectionString = $"Server=yourServerName;Database={databaseName};User Id=yourUsername;Password=yourPassword;";
        using (SqlConnection newConnection = new SqlConnection(connectionString))
        {
            newConnection.Open();

            string createTableSql = @"
            CREATE TABLE Users (
              Username VARCHAR(255) NOT NULL UNIQUE,
              UserId INT IDENTITY(1,1) PRIMARY KEY,
              Phone VARCHAR(20),
              CreateDate DATETIME DEFAULT GETDATE(),
              Privileges VARCHAR(MAX)
            );";

            using (SqlCommand command = new SqlCommand(createTableSql, newConnection))
            {
               command.ExecuteNonQuery();
            }
            Console.WriteLine($"Таблица 'Users' создана успешно.");
        }   
      }
    }
    catch (SqlException ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
  }
}

// Здесь был дима демидов