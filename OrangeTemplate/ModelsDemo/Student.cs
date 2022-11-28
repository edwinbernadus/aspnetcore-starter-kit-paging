using System;

namespace OrangeTemplate.ModelsDemo
{


    public class Student
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string StudentName { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset InfoDate { get; set; }
        public string Status { get; set; }
    }
}