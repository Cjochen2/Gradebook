using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args) /*Main is passing an array of strings as args*/
        {
            /*var numbers = new[] { 88.7, 99.7, 69.5 }; This is initializing an array with these three numbers*/

            var grades = new List<double>() { 88.7, 99.7, 69.5 }; /*This is initializing a List type from the System.Collections.Generic namspace with these three numbers*/

            var results = 0.0;

            foreach (var number in grades)
            {
                results += number;

                results /= grades.Count;
            }

            Console.WriteLine($"The average grade is {results:N1}");

            if (args.Length > 0)
            {
                Console.WriteLine($"Hello, {args[0]}!");
            }
            else
            {
                Console.WriteLine("Hello!");
            }
        }
    }
}
