using System;

namespace StudentsManagement.ConsoleApp.Entities
{
    public class Student
    {
        public int RollNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Course { get; set; }
    }
}
