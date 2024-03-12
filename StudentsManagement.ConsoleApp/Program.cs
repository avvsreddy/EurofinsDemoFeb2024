using StudentsManagement.ConsoleApp.Entities;
using System;
using System.Data.SqlClient;

namespace StudentsManagement.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // collect student data from user and store into database

            // in UI
            Student student = new Student
            {
                FirstName = "Rohith",
                LastName = "Kumar",
                Dob = DateTime.Parse("01/10/2009"),
                Email = "rohit@mail.com",
                Mobile = "3423423423",
                Course = "Computer Science"
            };

            // in DAL
            // DB Server: SQL Server
            // Database: StudentsDB2024
            // Table: Students
            // Framework : ADO.Net
            // Approach: Connected Approach



            // Step 1: connect to DB
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=StudentDB2024;Integrated Security=true";
            conn.Open();
            Console.WriteLine("Connected...");

            // Step 2: send sql commonds to db - select/insert/delete/update
            string sqlInsert = $"insert into students values ('{student.FirstName}','{student.LastName}','{student.Dob}','{student.Email}','{student.Mobile}','{student.Course}')";

            SqlCommand cmd = new SqlCommand(sqlInsert, conn);
            //cmd.Connection = conn;
            //cmd.CommandText = sqlInsert;
            cmd.ExecuteNonQuery();

            // Step 3: process the returned data
            // Step 4: close db connection
            conn.Close();

            Console.WriteLine("saved...");


        }
    }
}
