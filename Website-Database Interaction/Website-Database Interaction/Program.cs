using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace Website_Database_Interaction
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionStr = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\student\Source\Repos\personal - projects\ACM - Website\Source\ACM - Website\App_Data\localDB.mdf; Integrated Security = True";
            while (true)
            {
                SqlConnection connection = new SqlConnection(connectionStr);
                SqlCommand command;
                SqlDataReader reader;
                string sql;
                Console.WriteLine("Input an SQL command to be executed");
                sql = Console.ReadLine();
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection opened");
                    command = new SqlCommand(sql, connection);
                    Console.WriteLine("Command parsed");
                    reader = command.ExecuteReader();
                    Console.WriteLine("Reader executed");
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetValue(0) + "-" + reader.GetValue(1) + "-" + reader.GetValue(2));
                    }
                    Console.WriteLine("Reader finished");
                    reader.Close();
                    command.Dispose();
                    connection.Close();
                }
                catch (Exception e)
                {
                    connection.Close();
                    Console.WriteLine("Something went wrong");
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

    }
}
