﻿using StudentsManagement.ConsoleApp.Entities;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

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
                //FirstName = "Rohith",
                FirstName = "db nutral code",
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
            //SqlConnection conn = new SqlConnection();


            // get the factory

            string provider = ConfigurationManager.ConnectionStrings["defaultConnection"].ProviderName;
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            IDbConnection conn = factory.CreateConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            //conn.Open();
            //Console.WriteLine("Connected...");

            // Step 2: send sql commonds to db - select/insert/delete/update

            // SQL Injection

            //string sqlInsert = $"insert into students values ('{student.FirstName}','{student.LastName}','{student.Dob}','{student.Email}','{student.Mobile}','{student.Course}')";

            string sqlInsert = $"insert into students values (@fname,@lname,@dob,@email,@mobile,@course)";

            //SqlCommand cmd = new SqlCommand(sqlInsert, conn);
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sqlInsert;
            cmd.Connection = conn;
            //SqlParameter p1 = new SqlParameter();
            IDbDataParameter p1 = cmd.CreateParameter();

            p1.ParameterName = "@fname";
            p1.Value = student.FirstName;
            cmd.Parameters.Add(p1);

            //cmd.Parameters.AddWithValue("@lname", student.LastName);
            IDbDataParameter p2 = cmd.CreateParameter();
            p2.ParameterName = "@lname";
            p2.Value = student.LastName;
            cmd.Parameters.Add(p2);

            //SqlParameter p3 = new SqlParameter();
            IDbDataParameter p3 = cmd.CreateParameter();
            p3.ParameterName = "@dob";
            p3.Value = student.Dob;
            cmd.Parameters.Add(p3);

            //SqlParameter p4 = new SqlParameter();
            IDbDataParameter p4 = cmd.CreateParameter();
            p4.ParameterName = "@email";
            p4.Value = student.Email;
            cmd.Parameters.Add(p4);

            //SqlParameter p5 = new SqlParameter();
            IDbDataParameter p5 = cmd.CreateParameter();
            p5.ParameterName = "@mobile";
            p5.Value = student.Mobile;
            cmd.Parameters.Add(p5);

            //SqlParameter p6 = new SqlParameter();
            IDbDataParameter p6 = cmd.CreateParameter();
            p6.ParameterName = "@course";
            p6.Value = student.Course;
            cmd.Parameters.Add(p6);


            //cmd.Connection = conn;
            //cmd.CommandText = sqlInsert;
            using (conn)
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                //
                // Step 3: process the returned data
                // Step 4: close db connection
                conn.Close();
            }
            //
            Console.WriteLine("saved...");


        }
    }
}
