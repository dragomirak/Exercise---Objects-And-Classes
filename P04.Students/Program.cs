﻿namespace P04.Students
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] studentsInfo = Console.ReadLine().Split(" ");

                string firstName = studentsInfo[0];
                string lastName = studentsInfo[1];
                double grade = double.Parse(studentsInfo[2]);

                Student student = new Student(firstName, lastName, grade);
                students.Add(student);
            }

            List<Student> sortedStudents = students.OrderByDescending(student => student.Grade).ToList();

            foreach (Student student in sortedStudents)
            {
                Console.WriteLine(student);
            }
        }
    }
}