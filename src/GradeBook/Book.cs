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
            Name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public Statistics GetStatistics()
        {
            var results = new Statistics();
            results.High = double.MinValue;
            results.Low = double.MaxValue;

            foreach (var grade in grades)
            {
                results.High = Math.Max(grade, results.High);
                results.Low = Math.Min(grade, results.Low);

                results.Average += grade;
            }
            results.Average /= grades.Count;

            return results;
        }

        private List<double> grades;
        public string Name;
    }
}