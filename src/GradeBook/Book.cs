using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        /* This is an explicit constructor method. It needs to have the same name as the class and no return type */
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public void ShowStatistics()
        {
            var results = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;

            foreach (var number in grades)
            {
                highGrade = Math.Max(number, highGrade);
                lowGrade = Math.Min(number, lowGrade);

                results += number;
            }
            results /= grades.Count;

            Console.WriteLine($"The average grade is {results:N1}");
            Console.WriteLine($"The highest grade is {highGrade:N1}");
            Console.WriteLine($"The lowest grade is {lowGrade:N1}");
        }

        private List<double> grades;
        private string name;
    }
}