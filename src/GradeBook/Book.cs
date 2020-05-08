using System;
using System.Collections.Generic;

namespace GradeBook
{

    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class Book
    {
        /* This is an explicit constructor method. It needs to have the same name as the class and no return type */
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);

                if(GradeAdded !=  null)
                {
                    GradeAdded(this, new EventArgs());
                }

            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }

        }

        public event GradeAddedDelegate GradeAdded;

        public Statistics GetStatistics()
        {
            var results = new Statistics();
            results.High = double.MinValue;
            results.Low = double.MaxValue;

            for (var index = 0; index < grades.Count; index++)
            {
                results.High = Math.Max(grades[index], results.High);
                results.Low = Math.Min(grades[index], results.Low);
                results.Average += grades[index];
            }

            results.Average /= grades.Count;

            switch (results.Average)
            {
                case var d when d >= 90.0:
                    results.Letter = 'A';
                    break;

                case var d when d >= 80.0:
                    results.Letter = 'B';
                    break;

                case var d when d >= 70.0:
                    results.Letter = 'C';
                    break;

                case var d when d >= 60.0:
                    results.Letter = 'D';
                    break;

                default:
                    results.Letter = 'F';
                    break;
            }

            return results;
        }

        public void GradeEntry()
        {
            var check = true;

            while (check == true)
            {
                Console.WriteLine("Please Enter a Numerical grade value or press 'q' to exit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    check = false;
                    continue;
                }

                try
                {
                    var num = double.Parse(input);
                    AddGrade(num);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**********");
                }
            }
        }

        private List<double> grades;

        public string Name
        {
            get;
            set;

        }

        public const string CATEGORY = "Science";
    }
}